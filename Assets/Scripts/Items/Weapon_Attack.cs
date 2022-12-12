using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{

  void Awake()
  {
    playerBehaviour = GetComponentInParent<PlayerBehaviour>();
    wep = GetComponentInChildren<Weapon>();
  }

  private void Start()
  {
    LeftWeaponObject.SetActive(false);
    RightWeaponObject.SetActive(false);

    timer = wep.TimeToAttack;
  }

  void Update()
  {
    if (timer < wep.TimeToAttack)
    {
      timer += Time.deltaTime;
      return;
    }

    timer = 0;
    Attack();
  }
  private void Attack()
  {
    if (playerBehaviour.lastHorizontalVector < 0)
    {
      LeftWeaponObject.SetActive(true);
      //Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWeaponObject.transform.position, wep.Size, 0f);
      //ApplyDamage(colliders);
    }
    else
    {
      RightWeaponObject.SetActive(true);
      //Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWeaponObject.transform.position, wep.Size, 0f);
      //ApplyDamage(colliders);
    }
  }

  private void ApplyDamage(Collider2D[] colliders)
  {
    for (int i = 0; i < colliders.Length; i++)
    {
      Enemy e = colliders[i].GetComponent<Enemy>();
      if (e != null)
      {
        colliders[i].GetComponent<Enemy>().lastAttacker = GetComponentInParent<PlayerBehaviour>();
        colliders[i].GetComponent<Enemy>().TakeDamage(wep.Damage);
      }
    }
  }

  #region Properties
  [SerializeField] GameObject LeftWeaponObject;
  [SerializeField] GameObject RightWeaponObject;
  PlayerBehaviour playerBehaviour;

  Weapon wep;
  float timer;
  #endregion
}
