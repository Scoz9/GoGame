using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : SimpleEnemy
{
    private void Start()
    {
        speed = 2;
        range = 4;
        dir = 1;
        startingPosition = transform.position.x;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public override void Move() {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);
        if(transform.position.x < startingPosition || transform.position.x > startingPosition + range)
            dir *= -1;
    }
}
