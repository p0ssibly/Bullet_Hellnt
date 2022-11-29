using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{

    public GameObject PauseMenu;

    public static bool IsPaused = false;

    // Update is called once per frame
    void Start()
    {
        PauseMenu.SetActive(false);
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
    public void Resume() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitten Game...");
        Application.Quit();
    }
}
