using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private GroundCheck groundCheck;
    private PlayerMovement playerMovement;
    private bool canCombo = false;

    void Start(){
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0) && groundCheck.isGrounded){

            if (canCombo && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1")){
                anim.SetBool("Combo", true);
                canCombo = false;

                Invoke("DisableCombo", 0.5f);
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle") || 
                anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun")){
                // Set the "Attack" trigger in the Animator controller
                anim.SetTrigger("Attack");

                Invoke("EnableCombo", 0.3f);
            }
        }
    }

    void EnableCombo(){
        canCombo = true;
    }

    void DisableCombo(){
        anim.SetBool("Combo", false);
    }
}
