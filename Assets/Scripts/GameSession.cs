using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1.0f;
    public TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    // state variables
    private int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();    
    }

    // Update is called once per frame
    void Update () {
        gamePause();
	}

    public void gamePause(){


        if(!gamePaused){
            Time.timeScale = gameSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!gamePaused){
                Time.timeScale = 0f;
                gamePaused = true;
            }else{
                gamePaused = false;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
    }

    public void AddToScore()
    {
        PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") + 5);
        Debug.Log("CurrentScore: " + PlayerPrefs.GetInt("CurrentScore").ToString());
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
