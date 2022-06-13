using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int dir = 1;

    void Start()
    {
        startingY = transform.position.y;
    }

    //Per rendere il gioco più smoother
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * dir);
        if(transform.position.y < startingY || transform.position.y > startingY + range)
            dir *= -1;
    }
}