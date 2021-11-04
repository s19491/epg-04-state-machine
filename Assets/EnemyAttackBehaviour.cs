using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : StateMachineBehaviour
{
    private GameObject player;
    private EnemyScript enemy;
    private Rigidbody2D rigidbody;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = animator.GetComponent<EnemyScript>();
        rigidbody = enemy.GetComponent<Rigidbody2D>();

        checkHit();
    }

    private void checkHit() {
        LayerMask layerMask = LayerMask.GetMask("Default");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.hitCheck.position, enemy.hitCheckRadius, layerMask);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != enemy.gameObject && colliders[i].tag == "Player") {
                colliders[i].GetComponent<PlayerMovement>().TakeHit();
                Debug.Log("Enemy hits player");
                return;
            }
        }
    }
}
