using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame
{
    //private static string coinKey = "NumberOfCoins";
    public static void SaveCoins(int numberOfCoins)
    {
        PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);
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

    public static void SetCheckpointX(float x){
        PlayerPrefs.SetFloat("checkPointPositionX", x);
    }

    public static void SetCheckpointY(float y){
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public static float GetCheckpointX(){
        return PlayerPrefs.GetFloat("checkPointPositionX");
    }

    public static float GetCheckpointY(){
        return PlayerPrefs.GetFloat("checkPointPositionY");
    }

    public static int GetLevelAt(){
        return PlayerPrefs.GetInt("levelAt");
    }

    public static void SetLevelCheckpoint(int level){
        PlayerPrefs.SetInt("levelCheckpoint", level);
    }

    public static int GetLevelCheckpoint(){
        return PlayerPrefs.GetInt("levelCheckpoint");
    }

    public static void SetHighscoreMinutes(int minutes){
         PlayerPrefs.SetInt("HighscoreMinutes", minutes);
    }

    public static int GetHighscoreMinutes(){
        return PlayerPrefs.GetInt("HighscoreMinutes");
    }

    public static void SetHighscoreSeconds(float seconds){
        PlayerPrefs.SetFloat("HighscoreSeconds", seconds);
    }

    public static float GetHighscoreSeconds(){
        return PlayerPrefs.GetFloat("HighscoreSeconds");
    }

    public static void SetHighscore(string HighscorePlayingStr){
        PlayerPrefs.SetString("Highscore", HighscorePlayingStr);
    }

    public static string GetHighscore(){
        return PlayerPrefs.GetString("Highscore");
    }

    public static void SetHighscoreMinutes2(int minutes){
         PlayerPrefs.SetInt("HighscoreMinutes2", minutes);
    }

    public static int GetHighscoreMinutes2(){
        return PlayerPrefs.GetInt("HighscoreMinutes2");
    }

    public static void SetHighscoreSeconds2(float seconds){
        PlayerPrefs.SetFloat("HighscoreSeconds2", seconds);
    }

    public static float GetHighscoreSeconds2(){
        return PlayerPrefs.GetFloat("HighscoreSeconds2");
    }

    public static void SetHighscore2(string HighscorePlayingStr){
        PlayerPrefs.SetString("Highscore2", HighscorePlayingStr);
    }

    public static string GetHighscore2(){
        return PlayerPrefs.GetString("Highscore2");
    }

    public static void SetCheckpointTimer(string CheckpointTimerStr){
        PlayerPrefs.SetString("CheckpointTimer", CheckpointTimerStr);
    }

    public static string GetCheckpointTimer(){
        return PlayerPrefs.GetString("CheckpointTimer");
    }

     public static void SetCheckpointMinutes(int minutes){
        PlayerPrefs.SetInt("CheckpointMinutes", minutes);
    }

    public static int GetCheckpointMinutes(){
        return PlayerPrefs.GetInt("CheckpointMinutes");
    }

    public static void SetCheckpointSeconds(float seconds){
        PlayerPrefs.SetFloat("CheckpointSeconds", seconds);
    }

    public static float GetCheckpointSeconds(){
        return PlayerPrefs.GetFloat("CheckpointSeconds");
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