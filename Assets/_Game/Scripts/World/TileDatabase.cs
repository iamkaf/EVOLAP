using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDatabase : MonoBehaviour
{
  [SerializeField] private TileData[] tiles;

  private readonly Dictionary<TileData.TileType, TileData> _db = new Dictionary<TileData.TileType, TileData>();

  private void Awake()
  {
    foreach (TileData tile in tiles)
    {
      _db.Add(tile.type, tile);
    }
  }

  public TileData GetTile(TileData.TileType type)
  {
    if (type.Equals(TileData.TileType.AIR))
    {
      return null;
    }
    
    TileData tile;
    if (!_db.TryGetValue(type, out tile))
    {
      Debug.LogWarning($"Tried to get tile {type} but it wasn't found.", this);
    }
    return tile;
  }
}
