using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin
{
  private int _amplitude;
  private float _frequency;
  private int _seed;

  public Perlin(int amplitude = 256, float frequency = 1f, int seed = 100)
  {
    _amplitude = amplitude;
    _frequency = frequency;
    _seed = seed;
  }

  public Perlin(int amplitude, float frequency, string seed)
  {
    _amplitude = amplitude;
    _frequency = frequency;
    _seed = seed.GetHashCode();
  }

  public float GetValue(Vector2Int point) {
    return Mathf.PerlinNoise(CalculateCoord(point.x), CalculateCoord(point.y));
  }

  float CalculateCoord(int axis) => (float)axis / _amplitude * _frequency + _seed;
}
