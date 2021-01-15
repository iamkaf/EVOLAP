using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileData", menuName = "EVOLAP/TileData", order = 1)]
public class TileData : ScriptableObject
{
  public Sprite sprite;
  public TileType type;
  public Color color = Color.white;
  public Particle.Type particle;
  [Range(1, 5)] public int hardness = 1;
  [Range(1f, 5f)] public float reflectivity = 1f;
  [Range(1f, 5f)] public float luminosity = 1f;

  public enum TilemapLayer
  {
    // BASE,
    COLLISION,
    GLOW,
  }

  public enum TileType
  {
    AIR,
    BLUE_TILE,
    WHITE_TILE,
    BLACK_TILE,
    GREEN_TILE,
    RED_TILE,
    ORANGE_TILE,
  }

  public TilemapLayer tilemap = TilemapLayer.COLLISION;

  public static Tile CreateTile(TileData tileData)
  {
    if (tileData == null) return null;

    Tile t = ScriptableObject.CreateInstance<Tile>();
    t.sprite = tileData.sprite;
    t.color = tileData.color;
    t.colliderType = Tile.ColliderType.Grid;
    return t;
  }
}
