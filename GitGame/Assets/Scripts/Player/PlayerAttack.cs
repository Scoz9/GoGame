using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    private Animator anim;
    private KnightController playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<KnightController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++) enemiesToDamage[i].GetComponent<Goblin>().TakeDamage(damage);
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
            anim.SetTrigger("attack");
            cooldownTimer = 0;
    }

    //Per disegnare il cerchietto rosso relativo all'arma 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
