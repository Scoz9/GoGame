using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : ComplexEnemy
{
    public Transform borderCheck;
    public Animator anim;
    public GameObject hitbox;

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hp = 100;
        healthBar.value = hp;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        Move();
        FlipSprite();  
    }

    public override void takeDamage(int damageAmount)
    {
        hp -= damageAmount;
        healthBar.value = hp;
        if(hp > 0) anim.SetTrigger("damage");
        else  {
            anim.SetTrigger("death");
            GetComponent<PolygonCollider2D>().enabled = false;
            hitbox.SetActive(false);
            this.enabled = false;
        }
    }

    public override void Move()
    {
        float distance = Vector2.Distance(target.position, anim.transform.position);

        //IDLE STATE
        if(anim.GetBool("isAttacking") == false)
        {
            if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false) return;
            if (distance < 7) {
                anim.SetBool("isChasing", true);
                anim.SetBool("idle", false);
            }
        }
        
        //CHASE STATE
        if (anim.GetBool("isChasing") == true) {
            Vector2 newPos = new Vector2(target.position.x, anim.transform.position.y);
            anim.transform.position = Vector2.MoveTowards(anim.transform.position, newPos, speed * Time.deltaTime);
            if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false || distance < 1.3f)
                anim.SetBool("isChasing", false);
            if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
                anim.SetBool("idle", true);
            if (distance < 1.3f)
                anim.SetBool("isAttacking", true);
        }

        //ATTACK STATE
        if (distance > 1.5f)
            anim.SetBool("isAttacking", false);
    }

    public void FlipSprite()
    {
        if (target.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
