using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    void Start() {
        FindObjectsOfType<ToggleableLight>()
            .ForAll(light => light.TurnOn());
    }
}
