using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    private Animator anim;
    
    private void Start(){
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage){
        health -= damage;

        if (health <= 0){
            Die();
        } else {
            anim.SetTrigger("Hurt");
        }
    }

    private void Die(){
        anim.SetTrigger("Death");
        this.enabled = false;
    }
}
