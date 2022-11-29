using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  private void Awake()
  {
    //Size = GetComponent<Collider>().Wid;
  }

  public string Name;
  public float TimeToAttack;
  public int Damage;
  public Vector2 Size;
}
