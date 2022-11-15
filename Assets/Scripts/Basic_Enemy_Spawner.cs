using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_Spawner : MonoBehaviour
{
  void Start()
  {
  }

  void Update()
  {
    timer += Time.deltaTime;
    if (timer >= interval)
    {
      Vector2 randomPosition = origin + Random.insideUnitCircle * radius;
      Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
      timer -= interval;
    }
  }

  public Vector2 origin = Vector2.zero;
  public float radius = 10;
  public GameObject objectToSpawn;
  public float interval = 5;
  float timer;
}
