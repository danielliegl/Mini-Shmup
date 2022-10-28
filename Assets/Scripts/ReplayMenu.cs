using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{

  private GameManager gm_;
  [SerializeField] private GameObject win_text;
  [SerializeField] private GameObject lose_text;

  private void Start()
  {
    gm_ = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    if(gm_.game_won)
    {
      win_text.SetActive(true);
    }
    else
    {
      lose_text.SetActive(true);
    }
  }
  public void Replay()
  {
    SceneManager.LoadScene(0);
  }

  public void QuitGame()
  {
    Application.Quit();
  }


}
