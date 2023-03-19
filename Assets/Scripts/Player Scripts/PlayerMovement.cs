using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Horizontal movement
    public float runSpeed;
    private float inputHorizontal;

    // Jumping
    public float jumpingPower;
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;
    private GroundCheck groundCheck;
    private float gravity;
    [SerializeField]
    private float fastFallGravityMultiplier;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
        animator  = GetComponent<Animator>();
        gravity = rb.gravityScale;
    }

    private void Update(){
        
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0){
            rb.velocity = new Vector2(inputHorizontal * runSpeed, rb.velocity.y);
        } else if (groundCheck.isGrounded){
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        // Jumping
        if (groundCheck.isGrounded){
            coyoteTimeCounter = coyoteTime;
        } else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")){
            jumpBufferCounter = jumpBufferTime;
        } else {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
            animator.SetTrigger("Jump");
        }

        // Increase gravity when falling
        if (!groundCheck.isGrounded && rb.velocity.y < -0.1){
            rb.gravityScale = gravity * fastFallGravityMultiplier;
        } else {
            rb.gravityScale = gravity;
        }
        
    }

}
