using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    //[SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float range;

    float startingX;
    int dir = 1;

    void Start()
    {
        startingX = transform.position.x;
    }

    void FixedUpdate()
    {
        movementSideways();
    }

    /*private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }*/

    public void movementSideways()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);
        if(transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;
    }
}
