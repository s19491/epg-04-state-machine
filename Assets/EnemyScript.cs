using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int lives = 3;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        
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
