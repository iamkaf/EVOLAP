using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
  private int _chunkSize;
  public TileData[,] tileData;

  public Chunk(int chunkSize, TileData[,] tileData)
  {
    _chunkSize = chunkSize;
    this.tileData = tileData;
  }
}
