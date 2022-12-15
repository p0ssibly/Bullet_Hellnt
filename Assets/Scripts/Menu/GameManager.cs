using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public void GameOver()
  {
    Debug.Log("Game Over");
    SceneManager.LoadScene(2);
  }

  public void RestartButton()
  {
    SceneManager.LoadScene(1);
  }

  public void ExitButton()
  {
    SceneManager.LoadScene(0);
  }
}
