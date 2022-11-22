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

            Vector2 randomPosition = (Vector2)origin.transform.position + Random.insideUnitCircle * radius + offset;
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity,transform);
            timer -= interval;
        }
    }

    public Vector2 offset = Vector2.zero;
    public Transform origin;
    public float radius = 10;
    public GameObject objectToSpawn;
    public float interval = 5;
    float timer;

}
