using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bomb : Bullet
{

  [SerializeField] private float radius;
  [SerializeField] private BombWrapper effect_;

  // Start is called before the first frame update
  protected override void Start()
  {
    base.Start();
    speed_ = 8;
    damage_ = 5;
  }


  public override void onHit(Collider2D collision)
  {
    if(collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<Enemy>().shoot_through)
    {
      ExplosionDamage(gameObject.transform.position, radius);
      Destroy(gameObject);
    }
  }

  void ExplosionDamage(Vector3 center, float radius)
  {
    BombWrapper new_effect = Instantiate(effect_, gameObject.transform.position, Quaternion.identity);
    new_effect.gameObject.SetActive(false);
    new_effect.scale = radius;
    new_effect.gameObject.SetActive(true);
    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
    foreach (var hitCollider in hitColliders)
    {
      if(hitCollider.gameObject.tag == "Enemy")
      {
        Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
        enemy.take_damage(damage_);
        Debug.Log("Boom!");
      }
    }
  }

  

  // Update is called once per frame
  public override void UpdateFunction()
  {
    
  }
}
