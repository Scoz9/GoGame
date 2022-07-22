using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame
{
    //private static string coinKey = "NumberOfCoins";
    public static void SaveCoins(int numberOfCoins)
    {
        PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);
        //PlayerPrefs.Save();
    }

    public static int GetCoins()
    {
        return PlayerPrefs.GetInt("NumberOfCoins");
    }

    public static int GetLevelUnlocked(){
        return PlayerPrefs.GetInt("levelsUnlocked");
    }

    public static void SetLevelUnlocked(int currentLevel){
        PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
    }
    

    /*
    public static void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MUSIC", volume);
        PlayerPrefs.Save();
    }

    public static void SaveSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("SOUND", volume);
        PlayerPrefs.Save();
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MUSIC");
    }

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat("SOUND");
    }
    */
}