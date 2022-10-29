using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyProjectile : MonoBehaviour
{
  [SerializeField] public float speed_;

  private Rigidbody2D rb_;


  // Start is called before the first frame update
  void Start()
  {
    rb_ = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if(gameObject.transform.position.x < -11)
    {
      Destroy(gameObject);
    }
  }

  void FixedUpdate()
  {
    move();
  }

  public virtual void move()
  {
    rb_.velocity = new Vector2(-speed_, 0);
  }
}
