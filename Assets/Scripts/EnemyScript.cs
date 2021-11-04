using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float speed;
    public float chaseDistance = 8f;
    public float attackDistance = 2f;

    private int lives = 3;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (rb.velocity.x > 0) {
            spriteRenderer.flipX = false;
        } else if (rb.velocity.x < 0) {
            spriteRenderer.flipX = true;
        }
    }

    public void TakeHit() {
        Debug.Log("Taking Hit");
        animator.SetTrigger("TakeHit");

        lives--;
        if (lives == 0) {
            animator.SetBool("Dead", true);
        }
    }

    public void DisableColliders() {
        rb.simulated = false;
    }
}
