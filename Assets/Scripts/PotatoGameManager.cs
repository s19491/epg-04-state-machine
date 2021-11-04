using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoGameManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
 
    void Start() {
        GameEventSystem.Instance.OnPlayerWin += SetWinTextActive;
        GameEventSystem.Instance.OnPlayerLose += SetLoseTextActive;
    }


    void SetWinTextActive(bool win) {
        winText.gameObject.SetActive(win);
    }

    void SetLoseTextActive(bool lose) {
        loseText.gameObject.SetActive(lose);
    }

    private void OnDestroy() {
        GameEventSystem.Instance.OnPlayerInDangerZone -= SetWinTextActive;
    }
}
