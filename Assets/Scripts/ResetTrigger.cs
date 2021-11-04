using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTrigger : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameEventSystem.Instance.SetPlayerLose(true);
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        }
    }
}
