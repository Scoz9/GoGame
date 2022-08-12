using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake() {
		instance = this;
        maxHealth = 3;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        foreach(Image img in hearts)
            img.sprite = emptyHeart;
        
        for(int i = 0; i < currentHealth; i++)
            hearts[i].sprite = fullHeart;
    }
}
