using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainCamera : MonoBehaviour
{
  public GameObject target;
  public float speed = 2.0f;

  void Awake()
  {
    if (Application.isMobilePlatform)
    {
      GetComponent<Camera>().GetUniversalAdditionalCameraData().renderPostProcessing = false;
    }
  }

  void Update()
  {
    float interpolation = speed * Time.deltaTime;

    Vector3 position = this.transform.position;
    position.y = Mathf.Lerp(this.transform.position.y, target.transform.position.y, interpolation);
    position.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x, interpolation);

    this.transform.position = position;
  }
}
