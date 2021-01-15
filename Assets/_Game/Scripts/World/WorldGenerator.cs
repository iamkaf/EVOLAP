using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator
{
  public const int CHUNK_SIZE = 16;

  private WorldData world;
  private int amplitude;
  private float frequency;
  private int seed;

  public WorldGenerator(WorldData worldData, int worldSeed = 100)
  {
    world = worldData;
    amplitude = world.size;
    frequency = world.noiseScale;
    seed = worldSeed;
  }

  public WorldGenerator(WorldData worldData, string worldSeed)
  {
    world = worldData;
    amplitude = world.size;
    frequency = world.noiseScale;
    seed = worldSeed.GetHashCode();
  }

  public Chunk GenerateChunk(int chunkX, int chunkY)
  {
    int startX = chunkX * CHUNK_SIZE;
    int endX = chunkX * CHUNK_SIZE + CHUNK_SIZE - 1;
    int startY = chunkY * CHUNK_SIZE;
    int endY = chunkY * CHUNK_SIZE + CHUNK_SIZE - 1;

    TileData.TileType[,] tileData = new TileData.TileType[CHUNK_SIZE, CHUNK_SIZE];
    for (int x = 0; x < CHUNK_SIZE; x++)
    {
      for (int y = 0; y < CHUNK_SIZE; y++)
      {
        var blockPos = new Vector2Int(x, y);
        var chunkPos = new Vector2Int(chunkX, chunkY);
        tileData[x, y] = GenerateTileAt(ChunkPosToWorldPos(blockPos, chunkPos));
      }
    }

    return new Chunk(CHUNK_SIZE, tileData);
  }

  private TileData.TileType GenerateTileAt(Vector2Int pos)
  {
    float noiseValue = GetValue(pos);

    if (noiseValue > 0.66f) return world.resourceTile;
    if (noiseValue > 0.4f) return world.terrainTile;

    return TileData.TileType.AIR;
  }

  private float GetValue(Vector2Int point)
  {
    return Mathf.PerlinNoise(CalculateCoord(point.x), CalculateCoord(point.y));
  }

  private float CalculateCoord(int axis) => (float)axis / amplitude * frequency + seed;

  public static Vector2Int WorldPosToChunkPos(Vector2 pos) => WorldPosToChunkPos((Vector3)pos);
  public static Vector2Int WorldPosToChunkPos(Vector3 pos) => WorldPosToChunkPos(Vector3Int.FloorToInt(pos));
  public static Vector2Int WorldPosToChunkPos(Vector2Int pos) => WorldPosToChunkPos((Vector3Int)pos);
  public static Vector2Int WorldPosToChunkPos(Vector3Int pos) => new Vector2Int(
    Mathf.FloorToInt((float)pos.x / (float)CHUNK_SIZE),
    Mathf.FloorToInt((float)pos.y / (float)CHUNK_SIZE)
  );

  public static Vector2Int ChunkPosToWorldPos(Vector2Int blockPos, Vector2Int chunkPos) => chunkPos * CHUNK_SIZE + blockPos;
  public static Vector2Int WorldPosToPosInChunk(Vector2Int worldPos)
  {
    var offset = ChunkSizedVector();
    offset.x = Mathf.FloorToInt((float)worldPos.x / (float)CHUNK_SIZE) * CHUNK_SIZE;
    offset.y = Mathf.FloorToInt((float)worldPos.y / (float)CHUNK_SIZE) * CHUNK_SIZE;
    
    return worldPos - offset;
  }

  public static Vector2Int ChunkSizedVector() => new Vector2Int(CHUNK_SIZE, CHUNK_SIZE);
}
