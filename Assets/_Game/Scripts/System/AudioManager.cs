using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
  public Sound[] sounds;

  [HideInInspector] public Sound[] BGMs;

  public static AudioManager instance;

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

    foreach (Sound sound in sounds)
    {
      sound.source = gameObject.AddComponent<AudioSource>();
      sound.source.clip = sound.clip;
      sound.source.volume = sound.volume;
      sound.source.pitch = sound.pitch;
      sound.source.loop = sound.loop;

      if (sound.isBGM)
      {
        Array.Resize(ref BGMs, BGMs.Length + 1);
        BGMs[BGMs.GetUpperBound(0)] = sound;
      }
    }
  }

  void Start()
  {
    if (BGMs.Length == 0)
    {
      Debug.LogWarning("No BGMs were defined in the editor.");
      return;
    }
    StartCoroutine(ChangeBGM());
  }

  public void Play(string name)
  {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
      Debug.LogWarning("Tried to play sound " + name + " but it doesn't exist.");
      return;
    }
    s.source.Play();
  }

  IEnumerator ChangeBGM()
  {
    for (; ; )
    {
      foreach (Sound sound in BGMs)
      {
        sound.source.Stop();
      }

      Sound newBgm = Utility.Pick(BGMs);
      newBgm.source.Play();
      yield return new WaitForSecondsRealtime(newBgm.clip.length * 2);
    }
  }
}
