using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    public void Start()
    {
        //Timeout.timeScale = 1; //Se clicchiamo pausa e andiamo nel menu qualora avessimo il personaggino visibile nel menu senza questa istruzione la sua animazione idle non funzionerebbe
        mixer.GetFloat("volume",out value); //value deve essere passata con la keyword out
        volumeSlider.value = value;
    }
    
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void DeletePlayerPrefs()
    {
       PlayerPrefs.DeleteAll();  
    }
}
