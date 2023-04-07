using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightableObj : MonoBehaviour
{
    private GameObject light;
    private SpriteRenderer spriterend;
    private Animator animator;
    public bool lit;
    private Collider2D trigger;
    private Sprite normalsprite;

    void Start()
    {

        trigger = GetComponent<Collider2D>();
        spriterend = GetComponent<SpriteRenderer>();
        normalsprite = spriterend.sprite;
        light = gameObject.transform.GetChild(0).gameObject;
        light.SetActive(false);
        animator = GetComponent<Animator>();
        animator.enabled = false;
        lit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            Light();
            Destroy(other.gameObject);
        }
    }
    public void Light()
    {
        light.SetActive(true);
        animator.enabled = true;
        lit = true;
        trigger.enabled = false;
    }
    public void Unlight()
    {
        lit = false;
        light.SetActive(false);
        animator.enabled = false;
        spriterend.sprite = normalsprite;
        trigger.enabled = true;
    }
}
