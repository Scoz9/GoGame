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
    public int numberOfCoins;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject pauseMenuScreen;

    public void Awake()
    {
		instance = this;
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
            winOverScreen.SetActive(true);
    }

    public void LevelPassed(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel+1);

        //Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");
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
        SceneManager.LoadScene(level);
    }

}