using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEventSystem.Instance.SetPlayerInDangerZone(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEventSystem.Instance.SetPlayerInDangerZone(false);
    }
}
