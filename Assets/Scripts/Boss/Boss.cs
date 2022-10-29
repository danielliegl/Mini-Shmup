using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Boss : Enemy
{
  [SerializeField] private Enemy[] eyes_;
  Animator animation_;

  public override void customStart()
  {
    animation_ = gameObject.GetComponent<Animator>();
    animation_.Play("Boss");
  }

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

  public override void take_damage(int damage)
  {
    if(!invincible && health_ > 0)
    {
      animation_.Play("Boss_Damage");
      health_ -= damage;
      if(health_ <= 0)
      {
        onDeath();
        gm_.increaseScore(score_);
      }
    }
  }

  public override void onDeath()
  {
    animation_.Play("Death");
  }

  public void win()
  {
    gm_.gameOver(true);
  }

  void createExplosion()
  {
    float x_pos = Random.Range(-4.0f, 4.0f);
    float y_pos = Random.Range(-4.0f, 4.0f);

    Effect new_effect = Instantiate(effect_, gameObject.transform.position + new Vector3(x_pos, y_pos, 0), Quaternion.identity);
    new_effect.transform.SetParent(gameObject.transform);
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
