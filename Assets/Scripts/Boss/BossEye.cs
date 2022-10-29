using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : Enemy
{
    // Start is called before the first frame update
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
  }
}
