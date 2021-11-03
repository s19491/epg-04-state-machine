using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    private static GameEventSystem instance;

    public static GameEventSystem Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public event Action<bool> OnPlayerInDangerZone;
    public event Action<bool> OnPlayerWin;

    public void SetPlayerInDangerZone(bool isInDangerZone)
    {
        OnPlayerInDangerZone.Invoke(isInDangerZone);
    }

    public void SetPlayerWin(bool playerWin) {
        OnPlayerWin.Invoke(playerWin);
    }
}
