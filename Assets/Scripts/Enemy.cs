using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update
  public Transform target;
  public float speed;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.LookAt(target.position);
    transform.Rotate(new Vector3(0, -90, 0), Space.Self);

    if (Vector3.Distance(transform.position, target.position) > 1f)
    {
      transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
  }
}
