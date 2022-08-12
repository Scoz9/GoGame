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
    public int level;

    public static bool check;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(check == false)
            timeCounter.text = "Time: 00:00.00";
        if(check == true){
            timeCounter.text = SaveGame.GetCheckpointTimer();
        }
    
        timerGoing = false;
        
        if(level == 1)
            highscoreText.text = SaveGame.GetHighscore(); 
        else if(level == 2)
            highscoreText.text = SaveGame.GetHighscore2();   
    }

    public void BeginTimer(){
        timerGoing = true;

        if(check == false){
            elapsedTime = 0f;   
        }
        else if(check == true){
            elapsedTime = SaveGame.GetCheckpointSeconds();
        }

        startTime = Time.time;
        StartCoroutine(UpdateTimer());
    }

      public void EndTimer(){
        timerGoing = false;
        
        if(level == 1){
            if(SaveGame.GetHighscoreMinutes() == 0)
                SaveGame.SetHighscoreMinutes(minutes);
            if(SaveGame.GetHighscoreSeconds() == 0) 
                SaveGame.SetHighscoreSeconds(seconds);

            if(minutes == SaveGame.GetHighscoreMinutes()){
                if(seconds <= SaveGame.GetHighscoreSeconds()){
                    SaveGame.SetHighscoreSeconds(seconds);
                    SaveGame.SetHighscore(HighscorePlayingStr);
                }
            } else if(minutes < SaveGame.GetHighscoreMinutes()){
                SaveGame.SetHighscoreMinutes(minutes);
                SaveGame.SetHighscoreSeconds(seconds);
                SaveGame.SetHighscore(HighscorePlayingStr);
            }
            
            highscoreText.text = SaveGame.GetHighscore();
        }
        else if(level == 2){
            if(SaveGame.GetHighscoreMinutes2() == 0)
                SaveGame.SetHighscoreMinutes2(minutes);
            if(SaveGame.GetHighscoreSeconds2() == 0) 
                SaveGame.SetHighscoreSeconds2(seconds);
        
            if(minutes == SaveGame.GetHighscoreMinutes2()){
                if(seconds <= SaveGame.GetHighscoreSeconds2()){
                    SaveGame.SetHighscoreSeconds2(seconds);
                    SaveGame.SetHighscore2(HighscorePlayingStr);
                }
            } else if(minutes < SaveGame.GetHighscoreMinutes2()){
                SaveGame.SetHighscoreMinutes2(minutes);
                SaveGame.SetHighscoreSeconds2(seconds);
                SaveGame.SetHighscore2(HighscorePlayingStr);
            }
            highscoreText.text = SaveGame.GetHighscore2();
        }
        
    }

    public void CheckPointTimer(){
            //L'errore sta qua sistemato qua dovrebbe funzionare

            SaveGame.SetCheckpointMinutes(minutes);
            if(seconds != 0)
                SaveGame.SetCheckpointSeconds(seconds);
            
        
            if(!string.IsNullOrEmpty(timePlayingStr))
                SaveGame.SetCheckpointTimer(timePlayingStr);
            
            timePlayingStr = SaveGame.GetCheckpointTimer();
            //check = false;
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
            seconds = elapsedTime;
            //seconds = t % 60;

            //if(check == true){
                //Debug.Log("Dentro");
                //seconds = elapsedTime;
            //}
            
            yield return null;
        }
    }
}
