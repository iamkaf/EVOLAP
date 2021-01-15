using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerTileBuilder : MonoBehaviour
{
  [SerializeField] private TileData.TileType tileToBuild;
  [SerializeField] private float buildCooldown = 3f;

  private Cooldown blockPlaceCooldown;
  private Cooldown blockBreakCooldown;
  private GameManager game;
  private PlayerMovement playerMovement;
  private PlayerActionControls playerActionControls;

  void Awake()
  {
    game = GameObject.FindObjectOfType<GameManager>();
    playerMovement = GetComponent<PlayerMovement>();

    blockPlaceCooldown = new Cooldown(buildCooldown);
    blockBreakCooldown = new Cooldown(buildCooldown);

    playerActionControls = new PlayerActionControls();
  }

  void OnEnable()
  {
    playerActionControls.Enable();
    playerActionControls.Main.Place.performed += _ => BlockPlace();
  }

  void OnDisable()
  {
    playerActionControls.Main.Place.performed -= _ => BlockPlace();
    playerActionControls.Disable();
  }

    void Update()
  {
    BlockBreak();
  }

  void BlockPlace()
  {
    if (blockPlaceCooldown.CanUse() && !game.GetWorld().HasTileAt(GetTarget()))
    {
      game.GetWorld().SetTileAt(GetTarget(), tileToBuild);
      game.GetAudioManager().Play("BlockPlace");
      blockPlaceCooldown.Used();
    }
  }

  private void BlockBreak()
  {
    if (playerActionControls.Main.Break.ReadValue<float>() == 0f) return;

    TileData tile = game.GetWorld().GetTileAt(GetTarget());
    if (blockBreakCooldown.CanUse() && tile != null)
    {
      game.GetWorld().SetTileAt(GetTarget(), TileData.TileType.AIR);
      game.GetAudioManager().Play("BlockBreak");
      blockBreakCooldown.Used();
    }
  }

  private Vector3 GetTarget()
  {
    return transform.position + playerMovement.GetLastLookDirection();
  }
}
