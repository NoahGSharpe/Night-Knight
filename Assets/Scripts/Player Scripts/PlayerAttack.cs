using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private GroundCheck groundCheck;
    private PlayerMovement playerMovement;
    private bool canCombo = false;
    private bool comboWindowActive = false;


    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyLayers;

    [SerializeField] private float attackCooldown;
    private float attackCooldownTimer;

    void Start(){
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
        playerMovement = GetComponent<PlayerMovement>();
        attackCooldownTimer = attackCooldown;
    }

    void Update(){
        attackCooldownTimer -= Time.deltaTime;


        if (Input.GetMouseButtonDown(0) && groundCheck.isGrounded && attackCooldownTimer <= 0){

            if (canCombo && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1")){
                anim.SetBool("Combo", true);
                canCombo = false;

                Invoke("DisableCombo", 0.5f);
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun")){
                
                anim.SetTrigger("Attack");

                Invoke("EnableCombo", 0.3f);
            }
        }
    }

    public void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<IDamageable>().TakeDamage(1);
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null){
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void EnableCombo(){
        canCombo = true;
    }

    void DisableCombo(){
        anim.SetBool("Combo", false);
    }

    public void EnableComboWindow(){
        comboWindowActive = true;
    }

    public void DisableComboWindow(){
        comboWindowActive = false;
    }
}
