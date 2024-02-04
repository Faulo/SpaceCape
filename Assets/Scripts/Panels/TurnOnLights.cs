using SpaceCape.Extensions;
using UnityEngine;

namespace SpaceCape.Panels {
    public class TurnOnLights : MonoBehaviour {
        protected void Start() {
            FindObjectsOfType<ToggleableLight>()
                .ForAll(light => light.TurnOn());
        }
    }
}