using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour {
    public static GameEventSystem Instance;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public event Action<bool> OnPlayerInDangerZone;

    public void SetPlayerInDangerZone(bool isInDangerZone) {
        OnPlayerInDangerZone.Invoke(isInDangerZone);
    }
}
