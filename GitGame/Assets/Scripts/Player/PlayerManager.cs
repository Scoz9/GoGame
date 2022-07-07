using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static bool isWinOver;
    public GameObject winOverScreen;
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public GameObject pauseMenuScreen;

    public void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isWinOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        
        GameOver();
        WinLevel();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void WinLevel()
    {
        if(isWinOver)
        {
            winOverScreen.SetActive(true);
        }
    }

    public void GameOver()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToNextLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    //Da fare il tasto quit 
    /*public void QuitGame()
    {
        Application.Quit();
    }*/
}
