using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  [SerializeField] private GameManager gm_;

  public void OnePlayerGame()
  {
    gm_.multiplayer = false;
    gm_.startGame();
    SceneManager.LoadScene(1);
  }

  public void TwoPlayerGame()
  {
    gm_.multiplayer = true;
    gm_.startGame();
    SceneManager.LoadScene(1);
  }

  public void QuitGame()
  {
    Application.Quit();
  }


}
