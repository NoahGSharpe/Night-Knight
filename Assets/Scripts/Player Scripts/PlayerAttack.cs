using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private GroundCheck groundCheck;
    private PlayerMovement playerMovement;

    void Start(){
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0) && groundCheck.isGrounded){
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle") || 
                anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun")){
                // Set the "Attack" trigger in the Animator controller
                anim.SetTrigger("Attack");
            }
        }
    }
}
