using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeZone : MonoBehaviour
{
    [SerializeField]
    private TimeScale timeScale;

    public void OnTriggerEnter(Collider collider) {
        collider.GetComponents<ITimeable>()
            .ForAll(timeable => timeable.timeScale = timeScale);
    }

    public void OnTriggerExit(Collider collider) {
        collider.GetComponents<ITimeable>()
            .ForAll(timeable => timeable.timeScale = TimeScale.Normal);
    }
}
