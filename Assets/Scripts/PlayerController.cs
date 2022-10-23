using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

  [SerializeField] private float speed_;
  [SerializeField] private float fire_rate_;
  [SerializeField] private GameObject bullet_;


  private Rigidbody2D rb_;

  private bool can_fire = true;
  private int burst_counter = 0;
  
  // Start is called before the first frame update
  void Start()
  {
    rb_ = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    var horizontal_move_input = Input.GetAxisRaw("Horizontal");
    var vertical_move_input = Input.GetAxisRaw("Vertical");


    rb_.velocity = new Vector2(horizontal_move_input * speed_, vertical_move_input * speed_);

    if(can_fire && Input.GetButton("Fire1"))
    {
      Shoot();
    }
    
  }

  void Shoot()
  {
    Instantiate(bullet_, gameObject.transform.position, Quaternion.identity);
    can_fire = false;
    StartCoroutine(BulletTimer());
  }

  private IEnumerator BulletTimer()
  {
    burst_counter++;
    if (burst_counter < 3)
    {
      yield return new WaitForSeconds(1/fire_rate_);
    }
    else
    {
      burst_counter = 0;
      yield return new WaitForSeconds(3/fire_rate_);
    }
    can_fire = true;
  }
}
