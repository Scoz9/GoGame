
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    // Start is called before the first frame update
    public Text highscoreText;
    public Text scoreText;
    float timefl;
    int highscore;
    int time;
    bool finished = false;

    void Awake(){
        instance = this;
    
    }

    void Start(){
        timefl = 0;
        finished = false;
        scoreText.text = time.ToString();
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
        {   
            if(PlayerPrefs.GetInt("Highscore") == 0) {
                PlayerPrefs.SetInt("Highscore", time);
            }
            if(time < PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", time);
                highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            return;
        }
        timefl += Time.deltaTime*5;
        time = (int) timefl;
        scoreText.text = time.ToString();
    }


    public void Finish()
    {
        finished = true;
    }
}
