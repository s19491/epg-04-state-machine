using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingBehaviour : StateMachineBehaviour
{
    private PlayerMovement player;
    private EnemyScript enemy;
    private Rigidbody2D rigidbody;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemy = animator.GetComponent<EnemyScript>();
        rigidbody = enemy.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float distanceToPlayer = Vector2.Distance(animator.gameObject.transform.position, player.transform.position);

        if (player.health != 0) {
            if (distanceToPlayer < enemy.attackDistance) {
                if (Time.time - enemy.timeSinceLastAttack > enemy.attackSpeed) {
                    animator.SetTrigger("Attack");
                    enemy.timeSinceLastAttack = Time.time;
                }
            } else if (distanceToPlayer < enemy.chaseDistance) {
                Vector2 difference = (player.transform.position - enemy.transform.position).normalized;
                rigidbody.velocity = new Vector2(difference.x * enemy.speed, rigidbody.velocity.y);
            }
        }

        animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));
    }
}
