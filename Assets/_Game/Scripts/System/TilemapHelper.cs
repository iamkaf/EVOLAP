using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHelper : MonoBehaviour
{
  // [SerializeField] private Tilemap baseTilemap = null;
  [SerializeField] private Tilemap collisionTilemap = null;

  public bool HasTileAt(Vector3 pos)
  {
    return GetTileAt(pos) != null;
  }

  public TileBase GetTileAt(Vector3 pos)
  {
    return collisionTilemap.GetTile(Vec3ToVec3Int(pos));
  }

  public void SetTileAt(Vector3 pos, TileBase tile)
  {
    collisionTilemap.SetTile(Vec3ToVec3Int(pos), tile);
  }

  public void DeleteTileAt(Vector3 pos)
  {
    SetTileAt(pos, null);
  }


  public bool MoveTile(Vector3 from, Vector3 to)
  {
    TileBase tile = collisionTilemap.GetTile(Vec3ToVec3Int(from));
    if (tile == null)
    {
      return false;
    }

    collisionTilemap.SetTile(Vec3ToVec3Int(from), null);
    collisionTilemap.SetTile(Vec3ToVec3Int(to), tile);
    return true;
  }

  private Vector3Int Vec3ToVec3Int(Vector3 vec)
  {
    return new Vector3Int(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.y), Mathf.FloorToInt(vec.z));
  }
}
