using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    
    private float inputHorizontal;
    private bool facingRight = true;

    private Animator animator;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("SpeedX", Mathf.Abs(inputHorizontal));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("isGrounded", groundCheck.isGrounded);

        if (inputHorizontal > 0 && !facingRight){
            Flip();
        } else if (inputHorizontal < 0 && facingRight){
            Flip();
        }
    }

    
    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
