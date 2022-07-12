using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    void Awake()
    {
		instance = this;
    }
    // Update is called once per frame

    public void TakeDamage()
    {
        HealthManager.instance.health --;
        if(HealthManager.instance.health <= 0){
            GuiManager.instance.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
    }

    public void TakeDamageWater()
    {
        HealthManager.instance.health = 0;
        GuiManager.instance.isGameOver = true;
        AudioManager.instance.Play("GameOver");
        gameObject.SetActive(false);
    }

}
