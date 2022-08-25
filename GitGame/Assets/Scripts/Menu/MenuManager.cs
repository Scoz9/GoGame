using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public AudioMixer mixer;
    private float value;
    public static bool load;

    public void Start()
    {
        if(AudioOptionsManager.musicVolume == 0)
			AudioManager.instance.musicSlider.value =  1;
		else if(AudioOptionsManager.musicVolume != 0){
			AudioManager.instance.musicSlider.value =  AudioOptionsManager.musicVolume;
        }        

        if(AudioOptionsManager.soundEffectsVolume == 0)
           AudioManager.instance.effectsSlider.value = 1;
		else if(AudioOptionsManager.soundEffectsVolume != 0)
			AudioManager.instance.effectsSlider.value =  AudioOptionsManager.soundEffectsVolume;

        load = true;
    }
    
    public void LoadLevel(int index) 
    {
        Time.timeScale = 1;
        load = true;
        TimerController2.check = false; 
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string name) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void LoadLevel() 
    {
        Time.timeScale = 1;
        load = false;
        TimerController2.check = true;
        SceneManager.LoadScene(SaveGame.GetLevelCheckpoint());
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeletePlayerPrefs() 
    {
        PlayerPrefs.DeleteAll();
    }
}
