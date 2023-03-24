using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightableObj : MonoBehaviour
{
    private Light light;
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
        light = GetComponent<Light>();
        light.enabled = false;
        animator = GetComponent<Animator>();
        animator.enabled = false;
        lit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EditorOnly")
        {
            Light();
            Destroy(other.gameObject);
        }
    }
    public void Light()
    {
        light.enabled = true;
        animator.enabled = true;
        lit = true;
        trigger.enabled = false;
    }
    public void Unlight()
    {
        lit = false;
        light.enabled = false;
        animator.enabled = false;
        spriterend.sprite = normalsprite;
        trigger.enabled = true;
    }
}
