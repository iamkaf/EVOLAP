using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
  public static float Vec2Distance(Vector3 from, Vector3 to)
  {
    return Vector2.Distance((Vector2)from, (Vector2)to);
  }

  public static T Pick<T>(T[] arr)
  {
    return arr[(int)Math.Floor(UnityEngine.Random.value * arr.Length)];
  }
}
