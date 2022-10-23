using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemy
{

  override public void move()
  {
    rb_.velocity = new Vector2(-1 * speed_, 0);
  }

  override public void shoot()
  {

  }

}


