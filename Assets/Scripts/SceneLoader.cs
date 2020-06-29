using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    GameSession gameSession;
	public void LoadNextScene()
    {
        gameSession = gameObject.GetComponent<GameSession>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        if (currentSceneIndex == 0)
            gameSession.scoreText.text = "Score: 0";
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //FindObjectOfType<GameSession>().ResetGame();
        gameSession.scoreText.text = "";
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
