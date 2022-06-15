using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    private Rigidbody2D rb; 
    public float speed;
    private float moveInput;
    public float jumpForce;
    
    
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    private bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime;

    public float dashSpeed = 10;
    private bool isDashing = false;
    public float dashDuration = 0.2f;
    private float dashDurationStart;

    private Animator anim;

    
    void Start() {
        //Grab references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update() {
        KnightMovementRL(moveInput);
        KinghtJump();
        Dash();
        
        //Set animator parameters
        anim.SetBool("run", moveInput != 0);
        anim.SetBool("grounded", !isJumping);
        anim.SetBool("dash", isDashing);
    }

    public void KnightMovementRL(float moveInput){
        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0,0,0); //cavaliere guarda a destra
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0,180,0); //cavaliere guarda a sinistra
        }
    }

    public void KinghtJump(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //Se il player è sul pavimento e viene cliccato lo space -> isJumping(sta saltando) ... 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true ){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.Play("FirstJump");
        }

        //Se il player sta saltando ed lo spazio è premuto, continuerà a saltare per il tempo assegnato 
        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { //mette a false dopo aver superato il limite di tempo
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){  //si attiva se lascio "space" prima della fine del tempo
            isJumping = false;
        }
    }

    public void Dash() {
        if (Input.GetKeyDown("c") && isDashing == false) {
            isDashing = true; 
            speed += dashSpeed;
            dashDurationStart = dashDuration;
        }
        if (dashDurationStart <= 0 && isDashing == true) {
            isDashing = false; 
            speed -= dashSpeed;
        } else { 
            dashDurationStart -= Time.deltaTime;
        }
    }
}
