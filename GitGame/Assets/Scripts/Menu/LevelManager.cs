using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1); 

        for (int i = 0; i < lvlButtons.Length; i++)
                lvlButtons[i].interactable = false;


        for (int i = 0; i < levelsUnlocked; i++)
                lvlButtons[i].interactable = true;
    }

}
