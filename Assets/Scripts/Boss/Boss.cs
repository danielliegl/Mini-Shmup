using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
  [SerializeField] private Enemy[] eyes_;


  override public void move()
  {
    if(invincible && allEyesDestroyed())
    {
      invincible = false;
      shoot_through = false;
    }
  }

  override public void shoot()
  {

  }

  bool allEyesDestroyed()
  {
    foreach (Enemy eye in eyes_)
    {
      if(eye != null)
        return false;
    }
    return true;
  }
}
