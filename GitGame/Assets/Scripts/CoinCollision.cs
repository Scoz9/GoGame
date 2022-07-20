using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            CoinManager.instance.numberOfCoins++;
            AudioManager.instance.Play("Coins");
            SaveGame.SaveCoins(CoinManager.instance.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
