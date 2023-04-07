using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchThrow : MonoBehaviour
{
    private Camera cam;
    public GameObject torch;
    public float throwforce = 5f;
    public int torchnum;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
        direction.Normalize();

        if (Input.GetMouseButton(1) && torchnum > 0)
        {
            throwforce += 20*Time.deltaTime;
            throwforce = Mathf.Clamp(throwforce, 5, 20);
        }
        if (Input.GetMouseButtonUp(1) && torchnum > 0)
        {
            Vector3 spawnpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject projectile = Instantiate(torch, spawnpoint, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * throwforce);
            torchnum--;
            throwforce = 5;
        }

    }
}
