using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : SimpleEnemy {
    void Start()
    {
        speed = 2.5f;
        range = 3;
        startingPosition = transform.position.y;
        dir = 1;
    }

    void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * dir);
        if(transform.position.y < startingPosition || transform.position.y > startingPosition + range)
            dir *= -1;
    }
}
