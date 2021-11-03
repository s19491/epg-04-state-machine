using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGround : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject, 1f);
        }
    }
}
