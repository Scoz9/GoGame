using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    public void Start()
    {
        mixer.GetFloat("volume",out value); //value deve essere passata con la keyword out
        volumeSlider.value = value;
    }
    
    public void SetVolume() 
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index) 
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string name) 
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(name);
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
