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
  public int contactDamage = 10;
  public PlayerBehaviour lastAttacker;
  public int experience = 100;

  public ValueBar healthbar;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    currentHealth = maxHealth;
    healthbar.SetMaxValue(maxHealth);
    target = GameObject.FindWithTag("Player").transform;
    lastAttacker = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    playerInvulnerabilityTimer = int.MaxValue;
  }

  // Update is called once per frame
  void Update()
  {
    //target = GameObject.FindWithTag("Player").transform;
    Vector3 displacement = target.position - transform.position;
    displacement = displacement.normalized;
    if (Vector2.Distance(target.position, transform.position) > 0.9f)
    {
      transform.position += (displacement * speed * Time.deltaTime);
    }
  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthbar.SetValue(currentHealth);
    if (currentHealth <= 0)
    {
      if (lastAttacker) { lastAttacker.GiveExperience(experience); }
      Destroy(gameObject);
    }
  }

  float playerInvulnerabilityTimer = 0;
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (playerInvulnerabilityTimer > 1)
    {
      GameObject go = collision.gameObject;
      if (go.tag == "Player")
      {
        go.GetComponent<PlayerBehaviour>().TakeDamage(contactDamage);
      }

      playerInvulnerabilityTimer = 0;
    }

    playerInvulnerabilityTimer += Time.deltaTime;
  }

  public new SpriteRenderer renderer;
  public Animator animator;
}
