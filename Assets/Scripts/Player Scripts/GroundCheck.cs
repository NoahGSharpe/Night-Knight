using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D other) {
        isGrounded = other != null && (((1 << other.gameObject.layer) & groundLayer) != 0);
    }

    private void OnTriggerExit2D(Collider2D other) {
        isGrounded = false;
    }
}
