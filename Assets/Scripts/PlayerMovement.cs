using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private readonly string horizonMov = "Horizontal";

    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
        playerHealth = FindObjectOfType<HealthBarManager>();
    }

    // Update is called once per frame
    void Update() {
        gimOver(playerHealth.getHealth());
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            Debug.Log("keluar");
        }
    }

    void FixedUpdate()
    {
        //Movement
        Move();
        //Jumping
        Jump();
    }

    void gimOver(float currHealth) {
        if (currHealth < 0) {
        Debug.Log("Gim Over" + playerHealth.getHealth());
        //respawn?? ato gimana
        }
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true) {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        //SmoothJump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {
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
