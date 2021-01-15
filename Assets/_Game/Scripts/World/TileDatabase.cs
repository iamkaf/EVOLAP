using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDatabase : MonoBehaviour
{
  private Dictionary<TileData.TileType, TileData> tiles = new Dictionary<TileData.TileType, TileData>();

  private void Awake()
  {
    // Finds all TileData scriptable objects. Those must be within a folder called Resources
    // to be found. Then store them in a dictionary to be accessed later.
    var tileData = Resources.FindObjectsOfTypeAll<TileData>();
    foreach (var tile in tileData)
    {
      tiles.Add(tile.type, tile);
    }
  }

  public TileData GetTile(TileData.TileType type)
  {
    if (type.Equals(TileData.TileType.AIR))
    {
      return null;
    }

    TileData tile;
    if (!tiles.TryGetValue(type, out tile))
    {
      Debug.LogWarning($"Tried to get tile {type} but it wasn't found.", this);
    }
    return tile;
  }
}
