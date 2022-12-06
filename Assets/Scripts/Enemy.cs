using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  private Transform target;
  public float speed;
  private Rigidbody2D rb;
  public int maxHealth = 100;
  public int currentHealth;
  public PlayerBehaviour lastAttacker;

  public ValueBar healthbar;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    currentHealth = maxHealth;
    healthbar.SetMaxValue(maxHealth);
  }

  // Update is called once per frame
  void Update()
  {

    target = GameObject.FindWithTag("Player").transform;
    Vector3 displacement = target.position - transform.position;
    displacement = displacement.normalized;
    if (Vector2.Distance(target.position, transform.position) > 1.0f)
    {
      transform.position += (displacement * speed * Time.deltaTime);

    }
    else
    {

    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    lastAttacker = collision.gameObject.GetComponent<PlayerBehaviour>();
    TakeDamage(30);
  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthbar.SetValue(currentHealth);
    if (currentHealth <= 0)
    {
        lastAttacker.ExperiencePoints =
            lastAttacker.ExperiencePoints + 20;
        Destroy(gameObject);
    }
  }

  public new SpriteRenderer renderer;
  public Animator animator;
}
