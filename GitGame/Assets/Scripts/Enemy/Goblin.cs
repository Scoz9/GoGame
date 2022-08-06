using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : ComplexEnemy
{
    public Transform borderCheck;
    public Animator anim;
    
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
    }

    public override void takeDamage(int damageAmount)
    {
        hp -= damageAmount;
        healthBar.value = hp;
        if(hp > 0) anim.SetTrigger("damage");
        else  {
            anim.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }
    }

    public override void Move()
    {
        if (target.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
