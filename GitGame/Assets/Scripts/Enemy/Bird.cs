using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bird : ComplexEnemy
{
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform BirdsGFX;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public int movementDistance;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        healthBar.value = hp;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    //Fa creare un nuovo percorso ogni .5 secondi (parametro passato a InvokerRepeating)
    void UpdatePath(){
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        float distance2 = Vector2.Distance(rb.position, target.position);
        //Debug.Log("distanceTarget" + distance2);
        if (path == null) return;

        if(distance2 < movementDistance){
            if (currentWaypoint >= path.vectorPath.Count) {
                reachedEndOfPath = true;
                return;
            } else
                reachedEndOfPath = false;

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
                currentWaypoint++;

            //Fa ruotare la sprite nella direzione in cui si muove **Da problemi di imprecisione!
            /*if (force.x >= 0.01f)
                BirdsGFX.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            else if (force.x <= -0.01f)
                BirdsGFX.localScale = new Vector3(-0.7f, 0.7f, 0.7f);*/
            
            if (target.position.x > transform.position.x)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
                
        }
    }

    public override void takeDamage(int damageTaken)
    {
        hp -= damageTaken;
        healthBar.value = hp;
        //if (hp > 0) anim.SetTrigger("damage");
        //else
        //{
        //anim.SetTrigger("death");
        if (hp <= 0) {
            GetComponent<CircleCollider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject);
        }
            
        //} 
        
        /*if (hp <= 0) this.enabled = false;
        Destroy(gameObject);*/
    } 
}
