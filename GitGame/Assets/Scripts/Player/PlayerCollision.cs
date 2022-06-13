using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Water") // 
        {
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }

    }
}