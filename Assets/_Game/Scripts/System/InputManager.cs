using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  [SerializeField]
  private Joystick joy;
  private bool isMobile;

  public static InputManager instance;

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

    isMobile = Application.isMobilePlatform;

    if (joy == null)
    {
      Debug.LogWarning("Mobile joystick reference not set in Player Movement component.");
    }
  }

  public Vector2 GetMovementAxis()
  {
    if (isMobile)
    {
      return new Vector2(joy.Horizontal, joy.Vertical);
    }
    return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  }

  public bool GetAction(string actionName)
  {
    if (isMobile) {
      // TODO: Figure out mobile input
      return false;
    }
    return Mathf.Abs(Input.GetAxis(actionName)) > 0f;
  }
}
