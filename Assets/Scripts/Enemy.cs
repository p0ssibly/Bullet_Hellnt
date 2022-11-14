using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  private Transform target;
  public float speed;
  void Start()
  {

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
}
