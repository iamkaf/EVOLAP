using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovableEntity
{
  [SerializeField]
  private float viewDistance = 8f;

  private PlayerMovement player;

  void Awake()
  {
    player = GameObject.FindObjectOfType<PlayerMovement>();
  }

  protected override Vector2 GetAxis()
  {
    if (Utility.Vec2Distance(transform.position, player.transform.position) <= viewDistance)
    {
      return player.transform.position - transform.position;
    }
    return Vector2.zero;
  }
}
