using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
  public string Name;
  public Sprite WeaponIcon;
  public Sprite WeaponSprite;
  public AnimatorController Animator;
  public float TimeToAttack;
  public int Damage;

  public Vector2 Size;

  //Fuer Projektile
  public bool IsProjectile;
  public float Speed;
  public int MaxPierce;
}
