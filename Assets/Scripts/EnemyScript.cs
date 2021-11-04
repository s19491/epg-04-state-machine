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
    public float attackSpeed;

    public Transform hitCheck;
    public float hitCheckRadius;

    public int lives = 3;

    public float timeSinceLastAttack = 0;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (rb.velocity.x > 0) {
            spriteRenderer.flipX = false;
            hitCheck.localPosition = new Vector2(Mathf.Abs(hitCheck.localPosition.x), hitCheck.localPosition.y);
        } else if (rb.velocity.x < 0) {
            spriteRenderer.flipX = true;
            hitCheck.localPosition = new Vector2(-Mathf.Abs(hitCheck.localPosition.x), hitCheck.localPosition.y);
        }
    }

    public void TakeHit() {
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
