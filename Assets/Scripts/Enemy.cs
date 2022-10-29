using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  [SerializeField] public int health_;
  [SerializeField] public float speed_;

  [SerializeField] public int score_;
  [SerializeField] public bool invincible = false;
  [SerializeField] public bool shoot_through = false;

  [SerializeField] public Effect effect_;

  public GameManager gm_;
  
  public Rigidbody2D rb_;

  // Start is called before the first frame update
  void Start()
  {
    rb_ = gameObject.GetComponent<Rigidbody2D>();
    gm_ = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    customStart();
  }

  public virtual void customStart()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(gameObject.transform.position.x < -11)
    {
      Destroy(gameObject);
    }
    move();
    shoot();
  }

  public virtual void take_damage(int damage)
  {
    if(!invincible)
    {
      health_ -= damage;
      if(health_ <= 0)
      {
        onDeath();
        gm_.increaseScore(score_);
        Destroy(gameObject);
      }
    }
  }

  public virtual void move()
  {

  }

  public virtual void shoot()
  {

  }

  public virtual void onDeath()
  {

  }
}
