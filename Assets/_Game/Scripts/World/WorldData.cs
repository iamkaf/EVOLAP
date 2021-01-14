using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldData", menuName = "EVOLAP/WorldData", order = 2)]
public class WorldData : ScriptableObject
{
  [Range(64, 512)] public int size = 128;
  [Range(15f, 100f)] public float noiseScale = 1;
  public Color ambientColor;

  public TileData baseTile;
  public TileData terrainTile;
  public TileData resourceTile;
}
