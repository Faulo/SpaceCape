using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTimeable : MonoBehaviour, ITimeable {
    public TimeScale timeScale { get; set; }

    void Update() {
        timeScale.ApplyTimeScale();
    }
    void LateUpdate() {
        timeScale.RestoreTimeScale();
    }
}
