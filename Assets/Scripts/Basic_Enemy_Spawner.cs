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
            if(timer >= newEnemy)
            {
                enemyObjectCount += 1;
                newEnemy += 120;
            }
      Vector2 randomPosition = origin + Random.insideUnitCircle * radius;
      Instantiate(objectToSpawn[enemyObjectCount], randomPosition, Quaternion.identity);
      interval += 5;
        }
  }

  public Vector2 origin = Vector2.zero;
  public float radius = 10;
  public GameObject[] objectToSpawn;
  public float interval = 5;
  public int enemyObjectCount = 0;
  public float newEnemy = 60;
  float timer;
}
