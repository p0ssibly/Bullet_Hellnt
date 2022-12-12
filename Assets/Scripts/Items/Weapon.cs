using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Weapon : MonoBehaviour
{
  private void Awake()
  {
    Size.x = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    Size.y = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    GameObject go = collision.gameObject;
    if(go.tag == "Enemy")
    {
      go.GetComponent<Enemy>().TakeDamage(Damage);
      
    }
  }

  public float TimeToAttack;
  public int Damage;

  public Vector2 Size;

  //Fuer Projektile
  public float Speed;
  public int MaxPierce;
}

[CreateAssetMenu]
public class WeaponData: ScriptableObject
{
  public string Name;
  public Weapon WeaponStats;
  public GameObject WeaponPrefabObject;
}