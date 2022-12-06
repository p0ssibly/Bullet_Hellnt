using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();

    CurrentHealth = maxHealth;
    ExperiencePoints = 0;
    Level = 1;
    healthBar.SetMaxValue(maxHealth);
    expBar.SetMaxValue(maxExp);

    lastHorizontalVector = 1;
  }

  void Update()
  {
    movementVector.x = Input.GetAxisRaw("Horizontal");
    movementVector.y = Input.GetAxisRaw("Vertical");

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

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      TakeDamage(20);
    }
  }

  public void TakeDamage(int damage)
  {
    CurrentHealth -= damage;
    if (currentHealth <= 0)
    {
      //TODO: Sterben
    }
  }

  public void LevelUp()
  {
    Level++;
    ExperiencePoints = 0;
    maxExp += maxExp / 3;
  }

  #region Properties

  private int experiencePoints;
  private int currentHealth;
  private int level;
  private Rigidbody2D rb;

  public ValueBar healthBar;
  public int maxHealth = 100;

  public LevelDisplay levelDisplay;
  public ValueBar expBar;
  public int maxExp = 100;

  public int CurrentHealth {
    get { return currentHealth; }
    set { currentHealth = value; healthBar.SetValue(currentHealth); }
  }
  public int ExperiencePoints {
    get { return experiencePoints; }
    set { 
        experiencePoints = value; 
        expBar.SetValue(experiencePoints);
        if (experiencePoints >= maxExp)
            LevelUp();
    }
  }
  public int Level {
    get { return level; }
    set { level = value; levelDisplay.SetLevel(level); }
  }

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

  public new SpriteRenderer renderer;
  public Animator animator;
  #endregion
}