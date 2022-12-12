using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_Projectile_Behaviour : MonoBehaviour
{
  private void Awake()
  {
    wep = GetComponent<Weapon>();
  }

  void Update()
  {
    transform.position += direction * wep.Speed * Time.deltaTime;

    if (Time.frameCount % 6 == 0)
    {
      HitTarget();
    }

  }

  private void HitTarget()
  {
    //anstatt 0.3f je nachdem weapon size verwenden
    Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);

    int countHit = 0;
    foreach (Collider2D target in hit)
    {
      Enemy enemy = target.GetComponent<Enemy>();
      if (enemy != null)
      {
        enemy.TakeDamage(wep.Damage);
        countHit += 1;
        break;
      }

      if (countHit >= wep.MaxPierce)
      {
        Destroy(gameObject);
      }
    }
  }

  public void SetDirection(float x, float y)
  {
    direction = new Vector3(x, y);

    if (x < 0)
    {
      Vector3 scale = transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
    }
  }

  Vector3 direction;
  Weapon wep;
}
