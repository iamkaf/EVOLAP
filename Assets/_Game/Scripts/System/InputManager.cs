using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  [SerializeField]
  private Joystick joy;
  private bool isMobile;

  public static InputManager instance;
}
