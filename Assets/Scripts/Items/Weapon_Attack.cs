using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Behaviour : MonoBehaviour
{

  void Start()
  {

  }

  void Update()
  {
    timer -= Time.deltaTime;
    if (timer < Wep.TimeToAttack)
    {
      Attack();
    }
  }

  #region Properties
  [SerializeField] GameObject LeftWeaponObject;
  [SerializeField] GameObject RightWeaponObject;

  public Weapon Wep;
  public PlayerBehaviour Player;

  float timer;

  private void Attack()
  {
    timer = Wep.TimeToAttack;

    RightWeaponObject.SetActive(true);
    LeftWeaponObject.SetActive(true);
  }
  #endregion
}
