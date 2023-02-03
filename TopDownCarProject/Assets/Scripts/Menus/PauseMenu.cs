using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public bool circuit1;
    public bool circuit2;

    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        /*
         * Check if game is paused
         */
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadOptions()
    {
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        if (circuit1)
        {
            SceneManager.LoadScene("Circuit1");
        }

        if (circuit2)
        {
            SceneManager.LoadScene("Circuit2");
        }
    }
}
