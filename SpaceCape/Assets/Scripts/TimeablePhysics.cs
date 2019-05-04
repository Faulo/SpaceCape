using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeablePhysics : MonoBehaviour, ITimeable {
    public TimeScale timeScale { get {
            return sanitizedTimeScale;
        }
        set {
            sanitizedTimeScale = value;
        }
    }
    private TimeScale sanitizedTimeScale;

    private Dictionary<TimeScale, float> drags = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 10 },
        { TimeScale.Normal, 1 },
        { TimeScale.Reverse, 0 },
        { TimeScale.Faster, 0 }
    };

    private Dictionary<TimeScale, float> gravities = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 0.5f },
        { TimeScale.Normal, 1.0f },
        { TimeScale.Reverse, 1.0f },
        { TimeScale.Faster, 10.0f }
    };

    private new Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rigidbody.drag = drags[timeScale];
        rigidbody.AddForce(-Vector3.up * Physics.gravity.magnitude * gravities[timeScale]);
        //timeScale.ApplyTimeScale();
    }

    void LateUpdate() {
        //timeScale.RestoreTimeScale();
    }
}
