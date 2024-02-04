using Extensions;
using UnityEngine;

public class TurnOffLights : MonoBehaviour {
    protected void Start() {
        FindObjectsOfType<ToggleableLight>()
            .ForAll(light => light.TurnOn());
    }
}
