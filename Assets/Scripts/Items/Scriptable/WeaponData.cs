using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class WeaponData : ScriptableObject
{
  public string Name;
  public Sprite WeaponIcon;
  public Sprite WeaponSprite;
  public AnimatorController Animator;
  public float TimeToAttack;
  public int Damage;
  public Vector2 Size;
}
