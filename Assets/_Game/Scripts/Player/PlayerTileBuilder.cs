using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileBuilder : MonoBehaviour
{
  [SerializeField] private Tile tileToBuild = null;
  [SerializeField] private float buildCooldown = 3f;

  private Cooldown blockPlaceCooldown;
  private Cooldown blockBreakCooldown;

  private GameManager game;
  private PlayerMovement playerMovement;

  void Awake()
  {
    game = GameObject.FindObjectOfType<GameManager>();
    playerMovement = GetComponent<PlayerMovement>();

    blockPlaceCooldown = new Cooldown(buildCooldown);
    blockBreakCooldown = new Cooldown(buildCooldown);
  }

  void Update()
  {
    if (blockPlaceCooldown.CanUse())
    {
      if (game.GetInputManager().GetAction("BlockPlace") && !game.GetTilemapHelper().HasTileAt(GetTarget()))
      {
        game.GetTilemapHelper().SetTileAt(GetTarget(), tileToBuild);
        game.GetAudioManager().Play("BlockPlace");
        blockPlaceCooldown.Used();
      }
    }
    if (blockBreakCooldown.CanUse())
    {
      if (game.GetInputManager().GetAction("BlockBreak") && game.GetTilemapHelper().HasTileAt(GetTarget()))
      {
        game.GetTilemapHelper().DeleteTileAt(GetTarget());
        game.GetAudioManager().Play("BlockBreak");
        game.GetEffectsManager().SpawnParticle("BlockBreak", GetTarget());
        blockBreakCooldown.Used();
      }
    }
  }

  private Vector3 GetTarget()
  {
    return transform.position + playerMovement.GetLastLookDirection();
  }
}
