using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private GameManager game;
  private PlayerActionControls playerActionControls;

  private Cooldown screenshotCooldown;

  void Awake()
  {
    game = GameObject.FindObjectOfType<GameManager>();
    playerActionControls = new PlayerActionControls();

    screenshotCooldown = new Cooldown(0.5f);
  }

  void OnEnable()
  {
    playerActionControls.Enable();
    playerActionControls.Main.Screenshot.performed += _ => StartCoroutine(OnScreenshot());
  }

  void OnDisable()
  {
    playerActionControls.Disable();
    playerActionControls.Main.Screenshot.performed -= _ => StartCoroutine(OnScreenshot());
  }

  IEnumerator OnScreenshot()
  {
    if (screenshotCooldown.CanUse())
    {
      screenshotCooldown.Used();
      var screenshotPath = BuildScreenshotFilename();
      Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));
      ScreenCapture.CaptureScreenshot(screenshotPath);
    };
    yield break;
  }

  string BuildScreenshotFilename()
  {
    var now = DateTime.Now.ToLocalTime();
    // var time = $"{now.Year}_{now.Month}_{now.Day}_{now.Millisecond}";
    var time = now.ToString("yyyyMMddHHmmssffff");
    string screenshotPath = $"{Application.persistentDataPath}/screenshots/screenshot_{time}.png";
    return screenshotPath;
  }
}
