using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Item : MonoBehaviour
{
  private void OnEnable()
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
  float timeToDisable = 0.8f;
  float timer;
  #endregion
}
