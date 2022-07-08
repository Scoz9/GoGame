using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdsGFX : MonoBehaviour
{
    public AIPath aIPath;   //Il nome dello script aggiunto al nemico per controllarlo 

    // Update is called once per frame
    void FixedUpdate()
    {
        if(aIPath.desiredVelocity.x >= 0.01f) 
           transform.localScale = new Vector3(1f, 1f, 1f);
        else if(aIPath.desiredVelocity.x <= -0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1f); 
    }

    public void movementBirdsGFX()
    {
        if(aIPath.desiredVelocity.x >= 0.01f) 
           transform.localScale = new Vector3(1f, 1f, 1f);
        else if(aIPath.desiredVelocity.x <= -0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1f); 
    }
}