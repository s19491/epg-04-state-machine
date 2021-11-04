using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int health;
    public int speed;
    public int sprintingSpeed;

    public float movementSmoothing;

    public int jumpForce;
    public int dashForce;

    public Transform groundCheck;
    public Transform hitCheck;

    public float groundCheckRadius;
    public float hitCheckRadius;

    private Rigidbody2D rb;
    public bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }

    private void FixedUpdate() {
        checkGrounded();
    }

    void Update() {
        float xDisplacement = Input.GetAxis("Horizontal");
        float actualSpeed = speed;

        if (xDisplacement > 0) {
            spriteRenderer.flipX = false;
            hitCheck.localPosition = new Vector2(Mathf.Abs(hitCheck.localPosition.x), hitCheck.localPosition.y);
        } else if (xDisplacement < 0) {
            spriteRenderer.flipX = true;
            hitCheck.localPosition = new Vector2(-Mathf.Abs(hitCheck.localPosition.x), hitCheck.localPosition.y);
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            actualSpeed = sprintingSpeed;
        }

        Vector3 targetVelocity = new Vector2(xDisplacement * actualSpeed, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        animator.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("ySpeed", rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            animator.SetTrigger("Attack");
            checkHit();
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            animator.SetBool("Dead", true);
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            animator.SetTrigger("TakeHit");
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

        UIManager.Instance.SetHealthText(health);
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

    private void checkHit() {
        LayerMask layerMask = LayerMask.GetMask("Enemy");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(hitCheck.position, hitCheckRadius, layerMask);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                colliders[i].GetComponent<EnemyScript>().TakeHit();
            }
        }
    }

    public void Push(Vector2 vector) {
        rb.AddForce(vector, ForceMode2D.Impulse);
    }

    public void TakeHit() {
        if (health > 0) {
            health--;
            UIManager.Instance.SetHealthText(health);
            
            if (health == 0) {
                animator.SetTrigger("Dead");
                GameEventSystem.Instance.SetPlayerLose(true);
            }
        }
    }
}
