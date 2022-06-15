using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CoinManager manager;

    private void Start() {
        manager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player") {
            manager.AddCoins(1);
           // AudioManager.instance.Play("Coins");
            Destroy(gameObject);
        }
    }  
}
