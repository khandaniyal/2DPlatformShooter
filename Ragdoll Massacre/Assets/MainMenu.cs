using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void exitGame()
  {
    Application.Quit();
    Debug.Log("Game exited");
  }

  public void startGame()
  {
    SceneManager.LoadScene("GameLevel");
  }
}
