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

    public HealthBar healthbar;
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

    //animator.SetFloat("Speed", Mathf.Abs(directionY) + Mathf.Abs(directionX));
       // Debug.Log("Enemy Y: " + directionY);
//Debug.Log("Enemy X: " + directionX);

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
        takeDamage(30);
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public new SpriteRenderer renderer;
    public Animator animator;
}
