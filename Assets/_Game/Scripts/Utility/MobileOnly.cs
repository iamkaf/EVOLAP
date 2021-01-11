using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileOnly : MonoBehaviour
{
  void Awake()
  {
    if (!Application.isMobilePlatform)
    {
      gameObject.SetActive(false);
    }
  }
}
