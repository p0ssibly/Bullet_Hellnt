using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuHandler : MonoBehaviour
{
  [SerializeField] GameObject UpgradePanel;
   public void Open()
  {
    UpgradePanel.SetActive(true);
    Time.timeScale = 0f;
  }
    
  public void Close()
  {
    UpgradePanel.SetActive(false);
  }
}
