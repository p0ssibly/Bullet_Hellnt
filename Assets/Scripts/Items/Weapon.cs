using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  public string Name;
  public float TimeToAttack { get; set; }
  public int Damage;
  public SpriteRenderer SpriteRenderer;
  public Animation Animation;
}
