using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingBehaviour : StateMachineBehaviour
{
    private GameObject player;
    private EnemyScript enemy;
    private Rigidbody2D rigidbody;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = animator.GetComponent<EnemyScript>();
        rigidbody = enemy.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        float distanceToPlayer = Vector2.Distance(animator.gameObject.transform.position, player.transform.position);

        if (distanceToPlayer < enemy.attackDistance) {
            animator.SetTrigger("Attack");
        } else if (distanceToPlayer < enemy.chaseDistance) {
            Debug.Log("Chase");
            Vector2 difference = (player.transform.position - enemy.transform.position).normalized;
            rigidbody.velocity = new Vector2(difference.x * enemy.speed, rigidbody.velocity.y);
        }

        animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));

        Debug.Log(enemy.GetComponent<Rigidbody2D>().velocity.x);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
