using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* We have to fix the bug that consist in: when the player jumps and at the end falls in the ground, he goes a bit more down respect the ground */
// Inserire la variabile per l'animator grounded 
//if grounded = false saltando diventa true e passiamo allo stato idle 
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

    private Animator anim;

    
    void Start()
    {
        //Grab references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update(){
        
        KnightMovementRL(moveInput);
        KinghtJump();
        
        //Set animator parameters
        anim.SetBool("run", moveInput != 0);
        anim.SetBool("grounded", !isJumping);
    }

    public void KnightMovementRL(float moveInput){
        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0,0,0);
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0,180,0); 
        }
    }

    public void KinghtJump(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //Se il playr è sul pavimento e viene cliccato lo space -> isJumping(sta saltando) ... 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true ){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        //Se il player sta saltando ed lo spazio è premuto, coltinuerà a saltare per il tempo assegnato 
        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }
    }

}
