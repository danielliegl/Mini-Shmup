using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] public int health_;
  [SerializeField] public float speed_;
  
  public Rigidbody2D rb_;

  // Start is called before the first frame update
  void Start()
  {
    rb_ = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    move();
    shoot();
  }

  public void take_damage(int damage)
  {
    health_ -= damage;
    if(health_ <= 0)
    {
        Destroy(gameObject);
    }
  }

  public virtual void move()
  {

  }

  public virtual void shoot()
  {

  }
}
