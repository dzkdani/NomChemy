using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            GetComponentInParent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            GetComponentInParent<PlayerMovement>().isGrounded = false;
        }
    }
}
