using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

  [SerializeField] private Enemy alien_;
  [SerializeField] private Enemy boss_;
  [SerializeField] private GameObject player_1;
  [SerializeField] private GameObject player_2;

  [SerializeField] public bool game_won = false;
  [SerializeField] private int total_score = 0;

  public int score = 0;
  public int difficulty = 1;
  private float difficulty_modifier = 1.0f;

  public bool multiplayer = false;

  private bool game_running = false;
  private bool can_spawn = true;
  private bool boss_spawned = false;


  // Start is called before the first frame update
  void Start()
  {
    DontDestroyOnLoad(this.gameObject);
  }

  public void startGame()
  {
    game_running = true;
    StartCoroutine(IncreaseDifficulty());

    if(multiplayer)
    {
      Instantiate(player_1, new Vector2(-7.0f, 2.0f), Quaternion.identity);
      Instantiate(player_2, new Vector2(-7.0f, -2.0f), Quaternion.identity);
      difficulty_modifier = 0.6f;
    }
    else
    {
      Instantiate(player_1, new Vector2(-7.0f, 0.0f), Quaternion.identity);
    }
  }


  // Update is called once per frame
  void Update()
  {
    if(game_running)
    {
      checkLose();
      if(can_spawn)
      {
        StartCoroutine(SpawnTimer(growth_function(difficulty)));
      }
    }

  }

  public GameObject[] getPlayers()
  {
    return GameObject.FindGameObjectsWithTag("Player");
  }

  void checkLose()
  {
    GameObject[] alive_players = GameObject.FindGameObjectsWithTag("Player");
    if(alive_players.Length == 0)
    {
      game_running = false;
      gameOver(false);
    }
  }

  public void gameOver(bool win)
  {
    game_won = win;
    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    
    foreach (GameObject player in players)
    {
      Destroy(player);
    }
    
    SceneManager.LoadScene(2);
  }

  float growth_function(float x)
  {
    return Mathf.Max((-0.2f * x + 4.0f)/difficulty_modifier, 1.25f);
  }

  void SpawnBoss()
  {
    //Spawn Boss!
    Debug.Log("Spawning BBEG");
    boss_spawned = true;
    Instantiate(boss_, new Vector2(5.5313f, -0.0187f), Quaternion.identity);
  }

  private IEnumerator SpawnTimer(float seconds)
  {
    can_spawn = false;
    yield return new WaitForSeconds(seconds);
    var position = new Vector2(12, Random.Range(-5.0f, 5.0f));

    Instantiate(alien_, position, Quaternion.identity);
    can_spawn = true;
  }

  private IEnumerator IncreaseDifficulty()
  {
    yield return new WaitForSeconds(3);
    difficulty++;
    if(difficulty > 10 && !boss_spawned)
    {
      SpawnBoss();
    }
    else
    {
      StartCoroutine(IncreaseDifficulty());
    }



  }

    public void increaseScore(int amount)
    {
      total_score += amount;
    }
}
