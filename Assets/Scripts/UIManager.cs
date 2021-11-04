using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    private static UIManager instance;

    public TextMeshProUGUI healthText;
    public static UIManager Instance {
        get {
            return instance;
        }
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void SetHealthText(int health) {
        this.healthText.text = "HP: " + health;
    }
}
