using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GuiManager : MonoBehaviour
{
    public static GuiManager instance;

    public bool isGameOver;
    [SerializeField] GameObject gameOverScreen;

    public bool isWinOver;
    [SerializeField] GameObject winOverScreen;
    //public int numberOfCoins;
    //[SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject pauseMenuScreen;
    
    public bool gamePlaying; 


    public void Awake()
    {
		instance = this;
        //numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isWinOver = false;
        gamePlaying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //coinsText.text = numberOfCoins.ToString();
        GameOver();
        WinLevel();
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        MenuManager.load = true;
        TimerController2.check = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReplayLevelCheckpoint()
    {
        Time.timeScale = 1;
        MenuManager.load = false;
        TimerController2.check = true;
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
            winOverScreen.SetActive(true);
    }

    public void LevelPassed(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= SaveGame.GetLevelUnlocked())
            SaveGame.SetLevelUnlocked(currentLevel+1);
    }

    public void GameOver()
    {
        if(isGameOver)
            gameOverScreen.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToNextLevel(int level)
    {
        MenuManager.load = true;
        //Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void BeginGame()
    {
        gamePlaying = true;
    }

}
