using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

  [SerializeField] private float speed_;
  [SerializeField] private float fire_rate_;
  [SerializeField] private GameObject bullet_;

  [SerializeField] private bool playerTwo;

  [SerializeField] private int bomb_ammo = 0;
  [SerializeField] private GameObject bomb_;

  private Rigidbody2D rb_;

  private bool can_fire = true;
  private int burst_counter = 0;
  private string horizontal_axis;
  private string vertical_axis;
  private string fire_button;
  private string bomb_button;

  private Animator animator_;
  
  // Start is called before the first frame update
  void Start()
  {
    rb_ = GetComponent<Rigidbody2D>();
    DontDestroyOnLoad(this.gameObject);
    setControls();
    animator_ = gameObject.GetComponent<Animator>();
  }

  void setControls()
  {
    if(playerTwo)
    {
      horizontal_axis = "P2 Horizontal";
      vertical_axis = "P2 Vertical";
      fire_button = "P2 Fire";
      bomb_button = "P2 Bomb";
    }
    else
    {
      horizontal_axis = "P1 Horizontal";
      vertical_axis = "P1 Vertical";
      fire_button = "P1 Fire";
      bomb_button = "P1 Bomb";
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

    ShootBomb();
    SetAnimation();
    
  }

  void SetAnimation()
  {
    if(bomb_ammo > 0)
    {
      animator_.Play("PlayerHasBomb");
    }
    else
    {
      animator_.Play("Player");
    }
  }

  void ShootBomb()
  {
    if(bomb_ammo > 0 && Input.GetButtonDown(bomb_button))
    {
      Instantiate(bomb_, gameObject.transform.position, Quaternion.identity);
      bomb_ammo--;
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
    if(collision.gameObject.tag == "Enemy" || 
      collision.gameObject.tag == "EnemyBullet")
    {
      Destroy(gameObject);
    }

    if(collision.gameObject.tag == "PowerUp")
    {
      collision.gameObject.GetComponent<PowerUp>().applyPowerUp(this);
      Destroy(collision.gameObject);
    }
  }

  public void addBombAmmo(int amount)
  {
    bomb_ammo += amount;
  }
}
