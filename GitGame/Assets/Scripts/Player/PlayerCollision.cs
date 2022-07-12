using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Goblin") 
        {
            Debug.Log("nemico");
            HealthManager.instance.health--;
            if(HealthManager.instance.health <= 0){
                GuiManager.instance.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false); 
            } else 
                StartCoroutine(GetHurt());
        } else if(collision.transform.tag == "Water")
        {
            HealthManager.instance.health = 0;
            GuiManager.instance.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
        else if(collision.transform.tag == "EndLevel")
        {
            GuiManager.instance.LevelPassed();
            GuiManager.instance.isWinOver = true;
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }

    }
    
    IEnumerator GetHurt()
    {
        //Physics2D.IgnoreLayerCollision(3,8);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1,0);
        //Physics2D.IgnoreLayerCollision(3,8, false);
    }
}
