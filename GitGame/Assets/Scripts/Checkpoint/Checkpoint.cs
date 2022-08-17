using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int levelCheckPoint;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            SaveGame.SetLevelCheckpoint(levelCheckPoint);
            collision.GetComponent<KnightController>().ReachedCheckPoint(transform.position.x, transform.position.y);
            TimerController2.check = true;
            TimerController2.instance.CheckPointTimer();
        }
    }
}
