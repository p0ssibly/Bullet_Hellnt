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
    ExpBar.SetMaxValue(MaxExp);

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

  public void TakeDamage(int damage)
  {
    Debug.Log($"Took Damage: {damage}");
    CurrentHealth -= damage;
    if (_currentHealth <= 0)
    {
            FindObjectOfType<GameManager>().GameOver();
    }
  }

  public void LevelUp()
  {
    Level++;
    ExperiencePoints = 0;
    MaxExp += MaxExp / 3;

    UpgradePanel.Open();
  }

  public void GiveExperience(int amount)
  {
    ExperiencePoints += amount;
  }

  #region Properties

  private int _experiencePoints;
  private int _currentHealth = 0;
  private int level;
  private Rigidbody2D rb;

  public ValueBar healthBar;
  public int maxHealth = 100;

  public LevelDisplay LevelDisplay;
  public ValueBar ExpBar;
  public int MaxExp = 100;

  public int CurrentHealth
  {
    get { return _currentHealth; }
    set
    {
      _currentHealth = value;
      healthBar.SetValue(CurrentHealth);
    }
  }
  public int ExperiencePoints
  {
    get { return _experiencePoints; }
    set
    {
      _experiencePoints = value;

      ExpBar.SetValue(_experiencePoints);
      if (_experiencePoints >= MaxExp) { LevelUp(); }
    }
  }
  public int Level
  {
    get { return level; }
    set
    {
      level = value;
      LevelDisplay.SetLevel(level);
    }
  }

  public int Shield;
  public int Armor;
  public float Critical;
  public float MovSpeed; //Speed multiplier

  [HideInInspector]
  public Vector3 movementVector;
  [HideInInspector]
  public float lastHorizontalVector = 1;
  [HideInInspector]
  public float lastVerticalVector;

  public new SpriteRenderer renderer;
  public Animator animator;

  [SerializeField] UpgradeMenuHandler UpgradePanel;
  #endregion
}