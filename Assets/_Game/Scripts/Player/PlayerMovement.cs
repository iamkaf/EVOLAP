using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovableEntity
{
  // private InputManager inputManager = null;
  private PlayerActionControls playerActionControls;

  void Awake()
  {
    playerActionControls = new PlayerActionControls();
  }

  void OnEnable()
  {
    playerActionControls.Enable();
  }

  void OnDisable()
  {
    playerActionControls.Disable();
  }

  protected override Vector2 GetAxis()
  {
    return new Vector2(
      playerActionControls.Main.MoveHorizontal.ReadValue<float>(),
      playerActionControls.Main.MoveVertical.ReadValue<float>()
    );
  }
}
