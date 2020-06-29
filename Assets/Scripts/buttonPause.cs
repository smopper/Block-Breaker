using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPause : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    GameSession theGameSession;
    // Update is called once per frame
    void start()
    {
        theGameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        gamePause();
    }

    public void gamePause()
    {


        if (!gamePaused)
        {
            Time.timeScale = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gamePaused)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                gamePaused = true;
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
        GameSession.gamePaused = false;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Menu");
        gamePaused = false;
        GameSession.gamePaused = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }
}
