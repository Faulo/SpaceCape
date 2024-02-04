using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeablePhysics : MonoBehaviour, ITimeable {
    [SerializeField]
    GameObject reversedObject;

    [SerializeField]
    GameObject slowedObject;

    [SerializeField]
    GameObject forwardedObject;

    float transitionTime = 2.0f;
    float transitionTimer {
        get {
            return sanitizedTransitionTimer;
        }
        set {
            transform.localScale = backupScale * (1f + (0.1f * Mathf.Sin(2 * (float)Math.PI * value / transitionTime)));
            sanitizedTransitionTimer = value;
        }
    }
    float sanitizedTransitionTimer;

    GameObject transitionObject {
        get {
            return timeScale switch {
                TimeScale.Slower => slowedObject,
                TimeScale.Normal => null,
                TimeScale.Faster => forwardedObject,
                TimeScale.Reverse => reversedObject,
                _ => throw new System.Exception("wtf: " + timeScale),
            };
        }
    }
    public TimeScale timeScale {
        get {
            return sanitizedTimeScale;
        }
        set {
            if (sanitizedTimeScale != value) {
                sanitizedTimeScale = value;
                transitionTimer = 0;
            }
        }
    }
    TimeScale sanitizedTimeScale;

    public AudioSource sfx { get; set; }

    Dictionary<TimeScale, float> drags = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 10 },
        { TimeScale.Normal, 0.5f },
        { TimeScale.Reverse, 0.5f },
        { TimeScale.Faster, 0 }
    };

    Dictionary<TimeScale, float> gravities = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 0.5f },
        { TimeScale.Normal, 1.0f },
        { TimeScale.Reverse, 1.0f },
        { TimeScale.Faster, 10.0f }
    };

    new Rigidbody rigidbody {
        get {
            return GetComponentInChildren<Rigidbody>();
        }
    }

    Vector3 backupScale;

    protected void Start() {
        backupScale = transform.localScale;
    }

    protected void FixedUpdate() {
        rigidbody.drag = drags[timeScale];
        rigidbody.AddForce(gravities[timeScale] * Physics.gravity.magnitude * -Vector3.up);
    }

    protected void LateUpdate() {
        if (transitionObject != null) {
            if (transitionTimer == 0.0f) {
                if (sfx != null) {
                    sfx.Play();
                }
            }

            transitionTimer += Time.deltaTime;
            if (transitionTimer > transitionTime) {
                transitionTimer = 0;
                Instantiate(transitionObject, transform.position, transform.rotation, transform.parent);
                Destroy(gameObject);
            }
        }
    }
}
