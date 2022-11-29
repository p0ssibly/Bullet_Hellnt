using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Item : MonoBehaviour
{
  void OnEnable()
  {
    timer = timeToDisable;
  }

  private void LateUpdate()
  {
    timer -= Time.deltaTime;
    if (timer < 0f)
    {
      gameObject.SetActive(false);
    }
  }

  #region Properties
  float timeToDisable = 0.6f;
  float timer;
  #endregion
}
