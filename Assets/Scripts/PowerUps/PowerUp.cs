using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour
{
  // Start is called before the first frame update

  private Rigidbody2D rb_;
  private BoxCollider2D bc_;

  [SerializeField] private float speed_ = 2.0f;

  void Start()
  {
    rb_ = gameObject.GetComponent<Rigidbody2D>();
    bc_ = gameObject.GetComponent<BoxCollider2D>();
    bc_.isTrigger = true;
    gameObject.tag = "PowerUp";
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if(gameObject.transform.position.x < -11)
    {
      Destroy(gameObject);
    }

    rb_.velocity = new Vector2(-1 * speed_, 0);
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      applyPowerUp(collision.gameObject.GetComponent<PlayerController>());
      Destroy(gameObject);
    }
  }


  public virtual void applyPowerUp(PlayerController player)
  {
    
  }

}
