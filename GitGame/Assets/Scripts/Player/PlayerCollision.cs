using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //private PlayerAttack playerAttack;

    /*private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy") // 
        {
            HealthManager.health--;
            if(HealthManager.health <= 0){
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
                
            } else  {
                StartCoroutine(GetHurt());
            }
        }
        if(collision.transform.tag == "Goblin") // 
        {                   
            HealthManager.health--;
            if(HealthManager.health <= 0){
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false); 
            } else  {
                StartCoroutine(GetHurt());
            }        

        }
        if(collision.transform.tag == "Water")
        {
            HealthManager.health = 0;
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }

        if(collision.transform.tag == "EndLevel")
        {
            YouWin.Pass();
            PlayerManager.isWinOver = true;
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }

    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3,8);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(3,8, false);
    }
}
