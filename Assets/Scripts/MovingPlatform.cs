using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private int currentPointIndex = 0;
    void Start() {
        transform.position = points[currentPointIndex].position;
        
    }

    void FixedUpdate() {
        if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 0.01f) {
            currentPointIndex++;

            if (currentPointIndex == points.Length) {
                currentPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.transform.SetParent(null);
    }
}
