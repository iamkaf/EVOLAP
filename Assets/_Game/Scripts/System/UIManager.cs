using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Slider healthBar = null;

  private PlayerStats playerStats;

  void Start()
  {
    playerStats = GameObject.FindObjectOfType<PlayerStats>();
  }

  void Update()
  {
    healthBar.value = (float)playerStats.GetHealth() / (float)playerStats.GetMaxHealth();
  }
}
