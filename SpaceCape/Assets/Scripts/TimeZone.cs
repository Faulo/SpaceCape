using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeZone : MonoBehaviour
{
    [SerializeField]
    private TimeScale timeScale;

    [SerializeField]
    private AudioSource sfx;

    public void OnTriggerStay(Collider collider) {
        collider.GetComponents<ITimeable>()
            .ForAll(timeable => { timeable.timeScale = timeScale; timeable.sfx = sfx; });
    }
    public void OnTriggerExit(Collider collider) {
        collider.GetComponents<ITimeable>()
            .ForAll(timeable => timeable.timeScale = TimeScale.Normal);
        if(sfx != null && sfx.isPlaying)
        {
            sfx.Stop();
        }
    }
}
