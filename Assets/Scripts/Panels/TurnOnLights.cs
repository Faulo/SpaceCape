using Extensions;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {
    protected void Start() {
        FindObjectsOfType<ToggleableLight>()
            .ForAll(light => light.TurnOn());
    }
}
