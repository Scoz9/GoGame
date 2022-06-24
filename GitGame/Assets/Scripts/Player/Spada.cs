using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spada : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goblin")
        {
            collision.GetComponent<Goblin>().TakeDamage(25);
        }
    }
}
