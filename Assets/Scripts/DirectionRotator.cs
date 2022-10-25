using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionRotator : MonoBehaviour
{
  public float Speed;
  public Transform Target;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);

    if (movementDirection != Vector2.zero)
    {
      
      Quaternion toRotation = Quaternion.LookRotation(new Vector3(0,0,1), movementDirection);
      toRotation *= Quaternion.Euler(0, 0, 90);

      transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Speed * Time.deltaTime);
    }

    //Infinite speeeen
    //transform.RotateAround(Target.transform.position, zAxis, Speed);
  }
}
