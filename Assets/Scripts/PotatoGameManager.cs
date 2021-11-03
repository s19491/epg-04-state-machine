using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoGameManager : MonoBehaviour
{
    public GameObject winText;

 
    void Start() {
        GameEventSystem.Instance.OnPlayerWin += SetWinTextActive;
    }


    void SetWinTextActive(bool win) {
        winText.gameObject.SetActive(win);
    }

    private void OnDestroy() {
        GameEventSystem.Instance.OnPlayerInDangerZone -= SetWinTextActive;
    }
}
