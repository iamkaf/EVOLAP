using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Particle
{
  public enum Type
  {
    NONE,
    BLUE_ENERGY,
    ORANGE_ENERGY,
    BLOCK_BREAK,
  }

  [InspectorName("Type")] public Type particleType;
  public GameObject particle;
}
