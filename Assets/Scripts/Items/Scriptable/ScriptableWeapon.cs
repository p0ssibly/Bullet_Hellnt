using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer), typeof(WeaponData))]
public class ScriptableWeapon : MonoBehaviour
{
  public WeaponData Data;
  private float timer;
  private SpriteRenderer spriteRenderer;
  private Animator anim;

  public void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();

    spriteRenderer.sprite = Data.WeaponSprite;
    if (Data.Animator) { anim.runtimeAnimatorController = Data.Animator; }
  }

  public void Update()
  {
    if (timer < Data.TimeToAttack)
    {
      timer += Time.deltaTime;
      return;
    }

    timer = 0;
    Attack();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    GameObject go = collision.gameObject;
    if (go.tag == "Enemy")
    {
      go.GetComponent<Enemy>().TakeDamage(Data.Damage);

    }
  }

  private void Attack()
  {
    //if (playerBehaviour.lastHorizontalVector < 0)
    //{
    //  LeftWeaponObject.SetActive(true);
    //}
    //else
    //{
    //  RightWeaponObject.SetActive(true);
    //}
  }
}