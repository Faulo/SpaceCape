using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    void Start()
    {
        FindObjectsOfType<ToggleableLight>()
            .ForAll(light => light.TurnOff());
    }
}
