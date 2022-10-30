using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : EnemyProjectile
{
  
  [SerializeField] private GameObject target;
  
  void Start()
  {

    Debug.Log("Start");
    GameManager gm_ = GameObject.Find("GameManager").GetComponent<GameManager>();

    GameObject[] players = gm_.getPlayers();

    int random_index = Random.Range(0, players.Length);
    
    GameObject target = players[random_index];
  }

  public override void move()
  {
    if(target == null)
    {
      Start();
    }

    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed_ * Time.deltaTime);


  }

}
