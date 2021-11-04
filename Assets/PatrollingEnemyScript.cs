using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyScript : MonoBehaviour {
    public Transform[] points;
    private EnemyScript enemy;
    private Rigidbody2D rigidbody;


    public int currentPointIndex = 0;
    public void Start() {
        transform.position = points[currentPointIndex].position;
        enemy = GetComponent<EnemyScript>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTowardsPoint() {
        if (Mathf.Abs(transform.position.x - points[currentPointIndex].position.x) < 0.1f) {
            currentPointIndex++;

            if (currentPointIndex == points.Length) {
                currentPointIndex = 0;
            }
        }

        Vector2 difference = (points[currentPointIndex].position - transform.position).normalized;
        rigidbody.velocity = new Vector2(difference.x * enemy.speed, rigidbody.velocity.y);
    }
}
