using SpaceCape.Extensions;
using UnityEngine;

namespace SpaceCape {
    public class TimeZone : MonoBehaviour {
        [SerializeField]
        TimeScale timeScale;

        AudioSource sfx {
            get {
                return GetComponent<AudioSource>();
            }
        }

        protected void OnTriggerStay(Collider collider) {
            collider.GetComponents<ITimeable>()
                .ForAll(timeable => {
                    timeable.timeScale = timeScale;
                    timeable.sfx = sfx;
                });
        }
        protected void OnTriggerExit(Collider collider) {
            collider.GetComponents<ITimeable>()
                .ForAll(timeable => timeable.timeScale = TimeScale.Normal);
            if (sfx != null && sfx.isPlaying) {
                sfx.Stop();
            }
        }
    }
}