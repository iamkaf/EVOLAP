using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  private AudioManager audioManager;
  private InputManager inputManager;
  private EffectsManager effectsManager;
  private TilemapHelper tilemapHelper;

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
    inputManager = GameObject.FindObjectOfType<InputManager>();
    effectsManager = GameObject.FindObjectOfType<EffectsManager>();
    tilemapHelper = GetComponent<TilemapHelper>();
  }

  public AudioManager GetAudioManager()
  {
    return audioManager;
  }

  public InputManager GetInputManager()
  {
    return inputManager;
  }

  public EffectsManager GetEffectsManager()
  {
    return effectsManager;
  }

  public TilemapHelper GetTilemapHelper()
  {
    return tilemapHelper;
  }
}
