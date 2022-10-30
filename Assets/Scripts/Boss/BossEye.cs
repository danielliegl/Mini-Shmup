using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Animations;

public class BossEye : Enemy
{

  Animator animator_;
    // Start is called before the first frame update

  public override void customStart()
  {
    animator_ = gameObject.GetComponent<Animator>();
  }


  override public void move()
  {
    
  }

  override public void shoot()
  {

  }

  public override void onDeath()
  {
    base.onDeath();
    Instantiate(effect_, gameObject.transform.position, Quaternion.identity);
    Destroy(gameObject);
  }

public override void take_damage(int damage)
  {
    if(!invincible && health_ > 0)
    {
      animator_.Play("Eye_Damaged");
      health_ -= damage;
      if(health_ <= 0)
      {
        onDeath();
      }
    }
  }
}
