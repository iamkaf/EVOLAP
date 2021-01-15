using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[Serializable]
public class TileGrid
{
  public int _chunkSize;
  public TileData.TileType[,] _tiles;

  public TileGrid()
  {

  }

  public TileGrid(int chunkSize, TileData.TileType[,] tileData)
  {
    _chunkSize = chunkSize;

    _tiles = new TileData.TileType[chunkSize, chunkSize];
    for (int x = 0; x < chunkSize; x++)
    {
      for (int y = 0; y < chunkSize; y++)
      {
        _tiles[x, y] = tileData[x, y];
      }
    }
  }
}

public class Chunk
{
  private int _chunkSize;
  private Vector2Int _chunkPos;
  private TileGrid grid;

  public Chunk(Vector2Int chunkPos, int chunkSize, TileData.TileType[,] tileData)
  {
    _chunkSize = chunkSize;
    _chunkPos = chunkPos;

    this.grid = new TileGrid(chunkSize, tileData);
  }

  public Chunk(Vector2Int chunkPos, int chunkSize)
  {
    _chunkSize = chunkSize;
    _chunkPos = chunkPos;

    this.grid = new TileGrid(chunkSize, new TileData.TileType[chunkSize, chunkSize]);
  }

  public void SetTile(Vector2Int pos, TileData.TileType tile)
  {
    grid._tiles[pos.y, pos.x] = tile;
    // may perform poorly, potentially many IO operations
    Save();
  }

  public TileData.TileType GetTile(Vector2Int pos)
  {
    return grid._tiles[pos.y, pos.x];
  }

  public TileData.TileType[,] GetGrid()
  {
    return grid._tiles;
  }

  public static Chunk TryLoadFromFile(Vector2Int pos, int chunkSize)
  {
    if (!File.Exists(BuildChunkFilename(pos, chunkSize)))
    {
      return null;
    }
    
    Chunk chunk = new Chunk(pos, chunkSize);
    if (!chunk.Load()) {
      return null;
    }
    return chunk;
  }

  string BuildChunkFilename()
  {
    return $"{Application.persistentDataPath}/savedata/Chunk_{_chunkPos.x}_{_chunkPos.y}_{_chunkSize}.dat";
  }

  static string BuildChunkFilename(Vector2Int pos, int chunkSize)
  {
    return $"{Application.persistentDataPath}/savedata/Chunk_{pos.x}_{pos.y}_{chunkSize}.dat";
  }

  bool Load()
  {
    string chunkFile = BuildChunkFilename();
    if (File.Exists(chunkFile))
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(chunkFile, FileMode.Open);
      grid = new TileGrid();
      grid = (TileGrid)bf.Deserialize(file);
      file.Close();
      // Debug.Log($"Loading chunk from file {chunkFile}");
      return true;
    }
    return false;
  }

  public void Save()
  {
    string chunkFile = BuildChunkFilename();
    if (!File.Exists(chunkFile))
    {
      Directory.CreateDirectory(Path.GetDirectoryName(chunkFile));
    }
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Open(chunkFile, FileMode.OpenOrCreate);
    bf.Serialize(file, grid);
    file.Close();
    // Debug.Log($"Saving chunk to {chunkFile}");
  }
}
