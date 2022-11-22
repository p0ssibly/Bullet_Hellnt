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

  void Update()
  {
    timer -= Time.deltaTime;
    if (timer < wep.TimeToAttack)
    {
      Attack();
    }
  }

  #region Properties
  [SerializeField] GameObject LeftWeaponObject;
  [SerializeField] GameObject RightWeaponObject;
  [SerializeField] Vector2 WeaponAttackSize;
  PlayerBehaviour playerBehaviour;

  Weapon wep;
  float timer;


  private void Attack()
  {
    timer = wep.TimeToAttack;
    if (playerBehaviour.lastHorizontalVector > 0)
    {
      LeftWeaponObject.SetActive(true);
     Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWeaponObject.transform.position, WeaponAttackSize, 0f);
      ApplyDamage(colliders);
    }
    else
    {
      RightWeaponObject.SetActive(true);
      Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWeaponObject.transform.position, WeaponAttackSize, 0f);
      ApplyDamage(colliders);
    }
  }

  private void ApplyDamage(Collider2D[] colliders)
  {
    for(int i = 0; i < colliders.Length; i++)
    {
      Enemy e = colliders[i].GetComponent<Enemy>();
      if (e!= null)
      {
        colliders[i].GetComponent<Enemy>().TakeDamage(wep.Damage);
      }
    }
  }
  #endregion
}
