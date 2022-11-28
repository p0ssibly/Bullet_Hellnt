using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public static bool isPaused;

    // Update is called once per frame
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = if;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
