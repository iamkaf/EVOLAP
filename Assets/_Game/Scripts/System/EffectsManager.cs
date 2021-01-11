using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
  public Particle[] particles;

  public static EffectsManager instance;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);
  }

  public void SpawnParticle(string particleName, Vector3 where)
  {
    Particle particle = Array.Find(particles, arr => arr.name == particleName);
    if (particle == null)
    {
      Debug.LogWarning("Tried to spawn particle '" + particleName + "' but it doesn't exist.");
      return;
    }
    Instantiate(particle.particle, where, Quaternion.identity);
  }
}
