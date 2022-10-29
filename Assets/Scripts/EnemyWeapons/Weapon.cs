using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  [SerializeField] private EnemyProjectile projectile;
  [SerializeField] private float angle = 0.0f;
  [SerializeField] private float cooldown = 1.0f;

  private bool can_shoot = true;
  

  protected virtual void Start()
  {

  }

  void Update()
  {
    if(can_shoot)
    {
      shoot();
    }
  }
  public void shoot()
  {
    can_shoot = false;
    Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0,angle,angle));
    StartCoroutine(weaponCooldown(cooldown));
  }

  private IEnumerator weaponCooldown(float time)
  {
    yield return new WaitForSeconds(time);
    can_shoot = true;
  }


}
