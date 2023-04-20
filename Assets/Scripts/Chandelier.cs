using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject rope;
    private Animator ropeanim;
    private AudioSource audio;
    [SerializeField] private AudioClip ropesnap;
    [SerializeField] private AudioClip thud;
    //private Collider2D ropetrigger;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rope = gameObject.transform.GetChild(0).gameObject;
        ropeanim = rope.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        //ropetrigger = rope.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rope && ropeanim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(rope);
            audio.clip = ropesnap;
            rb.isKinematic = false;
            audio.Play();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            audio.clip = thud;
            audio.Play();
            rb.isKinematic = true;
            rb.velocity = new Vector2(0,0);
        }
        if (other.gameObject.tag == "Enemy" && rb.isKinematic == false)
        {
            //DamageEnemySomehow
        }
    }
}
