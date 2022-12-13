using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(BoxCollider2D))]
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

  private void Attack()
  {

  }
}