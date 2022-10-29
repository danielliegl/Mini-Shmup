using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : EnemyProjectile
{
  
  [SerializeField] private GameObject target;
  
  protected void Start()
  {
    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    int index = Random.Range(0, players.Length - 1);

    GameObject target = players[index];
  }

  public override void move()
  {
    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed_ * Time.deltaTime);
  }

}
