using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;
    public Animator anim;
    public Slider enemyHealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementGoblin();  
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if(enemyHP > 0)
            anim.SetTrigger("damage");
        else 
        {
            anim.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }
    }

    public void movementGoblin()
    {
        if(target.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0,180,0);
        else 
            transform.eulerAngles = new Vector3(0,0,0);
    }
}
