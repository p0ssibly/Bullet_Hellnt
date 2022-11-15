using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Instantiate(player, Vector3.zero, Quaternion.identity);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public GameObject player;
}
