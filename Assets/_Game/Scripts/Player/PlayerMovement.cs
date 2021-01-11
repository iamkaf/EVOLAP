using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovableEntity
{
  private InputManager inputManager = null;

  void Awake()
  {
    inputManager = GameObject.FindObjectOfType<InputManager>();
    if (inputManager == null)
    {
      Debug.LogError("Input manager not found in the scene!");
    }
  }

  protected override Vector2 GetAxis()
  {
    return inputManager.GetMovementAxis();
  }
}
