using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    currentHealth = maxHealth;
    healthbar.SetMaxHealth(maxHealth);
  }

  // Update is called once per frame
  void Update()
  {
    float directionX = Input.GetAxisRaw("Horizontal");
    float directionY = Input.GetAxisRaw("Vertical");

    direction = new Vector2(directionX, directionY).normalized;
  }

  private void FixedUpdate()
  {
    rb.velocity = new Vector2(direction.x * MovSpeed, direction.y * MovSpeed);
  }
    /*
  private void OnTriggerEnter(Collider2D collision)
  {
    if (collision.gameObject.tag == "Enemy") {
      Debug.Log(collision);
    }
  }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision);
            TakeDamage(10);
            Debug.Log(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {

        if (currentHealth <= 0)
        {
  
            //TODO: Sterben Funktion
        }
        else
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
        }
    }

  #region Properties

  public int Level;
  public int Shield;
  public int Armor;
  public float Critical;
  public float MovSpeed; //Speed multiplier

  private Rigidbody2D rb;
  private Vector2 direction;
  #endregion
}