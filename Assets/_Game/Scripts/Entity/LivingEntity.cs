using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
  [SerializeField] private string _name = "Unnamed";
  [SerializeField] private int _maxHealth = 100;
  private int _health = 100;

  public string GetName() => _name;
  public int GetMaxHealth() => _maxHealth;
  public int GetHealth() => _health;

  public virtual void SetName(string name)
  {
    _name = name;
  }

  public virtual void TakeDamage(int damage)
  {
    _health -= damage;
  }
}
