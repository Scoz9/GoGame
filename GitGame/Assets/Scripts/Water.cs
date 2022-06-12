using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private bool once = true;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.isGameOver = true;
            if(once){
                AudioManager.instance.Play("GameOver");
                once = false;
            }
            //Player.instance.SetActive(false);
        }
    }
}
