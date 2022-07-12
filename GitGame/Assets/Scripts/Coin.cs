using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GuiManager.instance.numberOfCoins++;
            AudioManager.instance.Play("Coins");
            PlayerPrefs.SetInt("NumberOfCoins", GuiManager.instance.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
