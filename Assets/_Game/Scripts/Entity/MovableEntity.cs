using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovableEntity : MonoBehaviour
{
  [Header("Movement")]
  [SerializeField]
  private float _speed = 5.0f;

  private Rigidbody2D _rb = null;

  protected Vector2 _movement;
  private Vector3 lastLookDirection = Vector3.zero;

  void Start()
  {
    _rb = gameObject.GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    Vector2 dir = GetAxis();
    _movement.x = dir.x;
    _movement.y = dir.y;

    if (Mathf.Abs(dir.x) > 0.3f || Mathf.Abs(dir.y) > 0.3f)
    {
      Vector3 lookAt = transform.position;
      lookAt.x += dir.x * 10;
      lookAt.y += dir.y * 10;

      lastLookDirection.x = dir.x;
      lastLookDirection.y = dir.y;

      var relativePos = lookAt - transform.position;
      var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
      var rotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
      transform.rotation = rotation;
    }

    // NormalizeVector2(_movement);
    _rb.MovePosition(_rb.position + _movement.normalized * _speed * Time.fixedDeltaTime);
  }

  private void NormalizeVector2(Vector2 vec)
  {
    // left
    if (vec.x < 0)
    {
      vec.x = -1;
    }

    // right
    if (vec.x > 0)
    {
      vec.x = 1;
    }

    // up
    if (vec.y < 0)
    {
      vec.y = -1;
    }

    // down
    if (vec.y > 0)
    {
      vec.y = 1;
    }

    vec.Normalize();
  }

  protected abstract Vector2 GetAxis();

  public Vector3 GetLastLookDirection()
  {
    return lastLookDirection;
  }
}
