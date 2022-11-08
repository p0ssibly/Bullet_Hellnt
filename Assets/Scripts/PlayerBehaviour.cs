using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
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

  private void OnTriggerEnter(Collider2D collision)
  {
    if (collision.gameObject.tag == "Enemy") {
      Debug.Log(collision);
    }
  }

  #region Properties

  public int Level;
  public int Health;
  public int Shield;
  public int Armor;
  public float Critical;
  public float MovSpeed; //Speed multiplier

  private Rigidbody2D rb;
  private Vector2 direction;
  #endregion
}