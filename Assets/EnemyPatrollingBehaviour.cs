using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingBehaviour : StateMachineBehaviour
{
    private PlayerMovement player;
    private EnemyScript enemy;
    private PatrollingEnemyScript patrollingEnemy;
    private Rigidbody2D rigidbody;

    void Start() {
       

    }

    void FixedUpdate() {

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemy = animator.GetComponent<EnemyScript>();
        patrollingEnemy = animator.GetComponent<PatrollingEnemyScript>();
        rigidbody = enemy.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float distanceToPlayer = Vector2.Distance(animator.gameObject.transform.position, player.transform.position);

        if (distanceToPlayer > enemy.chaseDistance) {
            patrollingEnemy.MoveTowardsPoint();
        }
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
