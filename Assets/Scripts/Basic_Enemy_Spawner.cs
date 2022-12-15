using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_Spawner : MonoBehaviour
{
  void Update()
  {
    timer += Time.deltaTime;
    if (timer >= interval)
    {
      if (timer >= newEnemy)
      {
        enemyObjectCount += 1;
        newEnemy += 60;
      }
      if (enemyObjectCount > objectToSpawn.Length - 1) { enemyObjectCount = objectToSpawn.Length - 1; }

      Vector2 randomPosition = (Vector2)GameObject.FindWithTag("Player").transform.position + Random.insideUnitCircle * radius + offset;

      for (int i = 0; i < Random.Range(1, 10); i++)
      {
        Instantiate(objectToSpawn[enemyObjectCount], new Vector2(randomPosition.x + Random.Range(1,5), randomPosition.y + Random.Range(1,5)), Quaternion.identity, transform);
      }

      interval += 5;
    }
  }

  public Vector2 offset = Vector2.zero;
  public float radius = 20;
  public GameObject[] objectToSpawn;
  public float interval = 5;
  public int enemyObjectCount = 0;
  public float newEnemy = 60;
  float timer;
}
