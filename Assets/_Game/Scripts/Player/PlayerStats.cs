using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : LivingEntity
{
  [SerializeField]
  private string playerName = "Hexy";

  void Awake()
  {
    SetName(playerName);
  }
}
