using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int speed;
    public int sprintingSpeed;

    public float movementSmoothing;

    public int jumpForce;
    public int dashForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    private Rigidbody2D rb;
    public bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void FixedUpdate() {
        checkGrounded();
    }

    void Update() {
        float xDisplacement = Input.GetAxis("Horizontal");

        float speedModifier = speed;

        if (Input.GetKey(KeyCode.LeftShift)) {
            speedModifier = sprintingSpeed;
        }

        Vector3 targetVelocity = new Vector2(xDisplacement * 100f * speedModifier * Time.deltaTime, rb.velocity.y);
        
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            if (xDisplacement > 0) {
                rb.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            } else if (xDisplacement < 0) {
                rb.AddForce(new Vector2(-dashForce, 0), ForceMode2D.Impulse);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Main");
        }
    }

    private void checkGrounded() {
        LayerMask layerMask = LayerMask.GetMask("Platform");
        isGrounded = false;

      
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, layerMask);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                isGrounded = true;
            }
        }

    }

    public void Push(Vector2 vector) {
        rb.AddForce(vector, ForceMode2D.Impulse);
    }
}
