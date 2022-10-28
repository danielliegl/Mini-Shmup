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

  [SerializeField] private bool playerTwo;

  private Rigidbody2D rb_;

  private bool can_fire = true;
  private int burst_counter = 0;
  private string horizontal_axis;
  private string vertical_axis;
  private string fire_button;
  
  // Start is called before the first frame update
  void Start()
  {
    rb_ = GetComponent<Rigidbody2D>();
    DontDestroyOnLoad(this.gameObject);
    setControls();
  }

  void setControls()
  {
    if(playerTwo)
    {
      horizontal_axis = "P2 Horizontal";
      vertical_axis = "P2 Vertical";
      fire_button = "P2 Fire";
    }
    else
    {
      horizontal_axis = "P1 Horizontal";
      vertical_axis = "P1 Vertical";
      fire_button = "P1 Fire";
    }
  }

  // Update is called once per frame
  void Update()
  {
    var horizontal_move_input = Input.GetAxisRaw(horizontal_axis);
    var vertical_move_input = Input.GetAxisRaw(vertical_axis);


    rb_.velocity = new Vector2(horizontal_move_input * speed_, vertical_move_input * speed_);

    if(can_fire && Input.GetButton(fire_button))
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

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Enemy")
    {
      Destroy(gameObject);
    }
  }
}
