using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    currentHealth = maxHealth;
    healthbar.SetMaxHealth(maxHealth);
  }

  void Update()
  {
    float directionX = Input.GetAxisRaw("Horizontal");
    float directionY = Input.GetAxisRaw("Vertical");

    if (movementVector.x != 0)
    {
      lastHorizontalVector = movementVector.x;
    }
    if (movementVector.y != 0)
    {
      lastVerticalVector = movementVector.y;
    }

    animator.SetFloat("Speed", Mathf.Abs(movementVector.y) + Mathf.Abs(movementVector.x));

    movementVector = new Vector3(movementVector.x, movementVector.y).normalized;
    if (movementVector.x < 0) { renderer.flipX = true; } else if (movementVector.x > 0) { renderer.flipX = false; }

    movementVector *= MovSpeed;
    rb.velocity = movementVector;
  }

  //private void FixedUpdate()
  //{
  //  rb.velocity = new Vector2(direction.x * MovSpeed, direction.y * MovSpeed);
  //}

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      TakeDamage(20);
    }
  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthbar.SetHealth(currentHealth);
    if (currentHealth <= 0)
    {
      //TODO: Sterben
    }
  }

  #region Properties

  public HealthBar healthbar;
  public int maxHealth = 100;
  public int currentHealth;

  public int Level;
  public int Shield;
  public int Armor;
  public float Critical;
  public float MovSpeed; //Speed multiplier

  [HideInInspector]
  public Vector3 movementVector;
  [HideInInspector]
  public float lastHorizontalVector;
  [HideInInspector]
  public float lastVerticalVector;

  private Rigidbody2D rb;
  public new SpriteRenderer renderer;
  public Animator animator;
  #endregion
}