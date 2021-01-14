using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDatabase : MonoBehaviour
{
  public enum TileType
  {
    AIR,
    BLUE_TILE,
    BLACK_TILE,
    GREEN_TILE,
    RED_TILE,
    ORANGE_TILE,
  }

  [Serializable]
  public class TileEntry {
    public TileType type;
    public TileData tile;
  }

  public TileEntry[] tiles;

  public TileData GetTile(TileType type)
  {
    return Array.Find(tiles, arr => arr.type.Equals(type)).tile;
  }
}
