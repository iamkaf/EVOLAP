using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  private AudioManager audioManager;
  private InputManager inputManager;
  private EffectsManager effectsManager;
  private WorldManager world;

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

    audioManager = GameObject.FindObjectOfType<AudioManager>();
    effectsManager = GameObject.FindObjectOfType<EffectsManager>();
    world = GameObject.FindObjectOfType<WorldManager>();
  }

  public AudioManager GetAudioManager()
  {
    return audioManager;
  }

  public EffectsManager GetEffectsManager()
  {
    return effectsManager;
  }

  public WorldManager GetWorld()
  {
    return world;
  }
}
