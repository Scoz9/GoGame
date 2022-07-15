using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController2 : MonoBehaviour
{
    public static TimerController2 instance;
    public Text timeCounter;
    public Text highscoreText;
    
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;
    private float seconds;
    private int minutes;
    private float startTime;
    private string timePlayingStr;
    private string HighscorePlayingStr;


    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        highscoreText.text = PlayerPrefs.GetString("Highscore"); 
    }

    public void BeginTimer(){
        timerGoing = true;
        elapsedTime = 0f;

        startTime = Time.time;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer(){
        timerGoing = false;
        
        if(PlayerPrefs.GetInt("HighscoreMinutes") == 0)
            PlayerPrefs.SetInt("HighscoreMinutes", minutes);
        if(PlayerPrefs.GetFloat("HighscoreSeconds") == 0) 
            PlayerPrefs.SetFloat("HighscoreSeconds", seconds);
        
        if(minutes == PlayerPrefs.GetInt("HighscoreMinutes")){
            if(seconds <= PlayerPrefs.GetFloat("HighscoreSeconds")){
                PlayerPrefs.SetFloat("HighscoreSeconds", seconds);
                PlayerPrefs.SetString("Highscore", HighscorePlayingStr);
            }
        } else if(minutes < PlayerPrefs.GetInt("HighscoreMinutes")){
            PlayerPrefs.SetInt("HighscoreMinutes", minutes);
            PlayerPrefs.SetFloat("HighscoreSeconds", seconds);
            PlayerPrefs.SetString("Highscore", HighscorePlayingStr);
        }
        highscoreText.text = PlayerPrefs.GetString("Highscore");
    }

    private IEnumerator UpdateTimer(){
        while(timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            HighscorePlayingStr = "Highscore: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;


            float t = Time.time - startTime;
            minutes = ((int) t / 60);
            seconds = t % 60;
            
            yield return null;
        }
    }
}
