using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1,10)]
    public float moveSpeed;
    private float movInput;
    private bool facingRight = true;
    [Range(0,2)]
    [SerializeField] private float fallMultiplier  = 2f;
    [Range(0,1)]
    [SerializeField] private float lowJumpMultiplier = 2f;
    [Range(1,10)]
    public float jumpVelocity;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    [SerializeField] private HealthBarManager playerHealth;

    private readonly string jmp = "Jump";
    private readonly string horizonMov = "Horizontal";

    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
        playerHealth = FindObjectOfType<HealthBarManager>();
    }

    // Update is called once per frame
    void Update() {
        //Nyawa
        if (playerHealth.currentHealth <= 0) {
            Debug.Log("Gim Over" + playerHealth.currentHealth);
        }
    }

    void FixedUpdate()
    {
        //Movement
        Move();
        //Jumping
        Jump();
    }
    
    void Move() {
        movInput = Input.GetAxis(horizonMov);
        Vector3 mov = new Vector3(movInput, 0f, 0f);
        transform.position += mov * Time.deltaTime * moveSpeed;
        if(facingRight == false && movInput > 0) {
            Flip();
        } else if (facingRight == true && movInput < 0) {
            Flip();
        }
    }

    void Jump() {

        //TheJump
        if (Input.GetButtonDown(jmp) && isGrounded == true) {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        //SmoothJump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton(jmp)) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }    
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
