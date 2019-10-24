using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1,10)]
    public float moveSpeed;
    private float movInput;
    private bool facingRight = true;
    public float fallMultiplier  = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1,10)]
    public float jumpVelocity;
    public bool isGrounded = false;
  
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        movInput = Input.GetAxis("Horizontal");
        Move();
        if(facingRight == false && movInput > 0) {
            Flip();
        } else if (facingRight == true && movInput < 0) {
            Flip();
        }
        //Jumping
        Jump();
    }
    
    void Flip() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void Move() {
        Vector3 mov = new Vector3(movInput, 0f, 0f);
        transform.position += mov * Time.deltaTime * moveSpeed;
    }

    void Jump() {

        //TheJump
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        //SmoothJump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
    }
}
