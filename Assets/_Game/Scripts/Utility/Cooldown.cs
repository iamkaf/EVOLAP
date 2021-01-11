using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
  private float _cooldown;
  private float _nextUseTime = 0;

  public Cooldown(float cooldown)
  {
    _cooldown = cooldown;
  }

  public void Used()
  {
    _nextUseTime = Time.time + _cooldown;
  }

  public bool CanUse()
  {
    return Time.time > _nextUseTime;
  }
}
