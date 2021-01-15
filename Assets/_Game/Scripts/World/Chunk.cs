using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
  private int _chunkSize;
  public TileData.TileType[,] tileData;

  public Chunk(int chunkSize, TileData.TileType[,] tileData)
  {
    _chunkSize = chunkSize;
    this.tileData = tileData;
  }
}
