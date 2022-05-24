using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public void movement(){
       float horizontal = Input.GetAxis("Horizontal");
       Vector2 character_position = transform.position;
       character_position.x += 3.0f * horizontal * Time.deltaTime;
       transform.position = character_position;
    }
}

// Implementare salto
