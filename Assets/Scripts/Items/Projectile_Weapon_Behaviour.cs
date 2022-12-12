using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Weapon_Behaviour : MonoBehaviour
{
  private void Awake()
  {
    playerBehaviour = GetComponentInParent<PlayerBehaviour>();
    wep = GetComponentInChildren<Weapon>();
  }

  void Update()
  {
    if (timer < wep.TimeToAttack)
    {
      timer += Time.deltaTime;
      return;
    }

    timer = 0;
    SpawnProjectile();
  }

  private void SpawnProjectile()
  {
    GameObject thrownProjectile = Instantiate(projectile);
    thrownProjectile.transform.position = transform.position;
    thrownProjectile.GetComponentInChildren<Throwing_Projectile_Behaviour>().SetDirection(playerBehaviour.lastHorizontalVector, 0f);
  }

  [SerializeField] GameObject projectile;
  PlayerBehaviour playerBehaviour;
  Weapon wep;
  float timer;
}
