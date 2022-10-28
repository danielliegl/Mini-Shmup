using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
  [SerializeField] private float speed_;
  [SerializeField] private int damage_;

  private Rigidbody2D rb_;


  // Start is called before the first frame update
  void Start()
  {
    rb_ = gameObject.GetComponent<Rigidbody2D>();
    speed_ = 17;
    damage_ = 1;
  }

  // Update is called once per frame
  void Update()
  {
    if(gameObject.transform.position.x > 11)
    {
      Destroy(gameObject);
    }


    rb_.velocity = new Vector2(speed_, 0);


  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<Enemy>().shoot_through)
    {
      collision.gameObject.GetComponent<Enemy>().take_damage(damage_);
      Destroy(gameObject);
    }
  }
}
