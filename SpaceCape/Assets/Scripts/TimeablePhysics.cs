using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeablePhysics : MonoBehaviour, ITimeable {
    [SerializeField]
    private GameObject reversedObject;

    [SerializeField]
    private GameObject slowedObject;

    [SerializeField]
    private GameObject forwardedObject;

    private bool forward = false;
    private bool rewind = false;
    private float transitionTime = 2.0f;
    private float transitionTimer {
        get {
            return sanitizedTransitionTimer;
        }
        set {
            transform.localScale = backupScale * (1f + 0.1f * Mathf.Sin(2 * (float) Math.PI * value / transitionTime));
            sanitizedTransitionTimer = value;
        }
    }
    private float sanitizedTransitionTimer;

    private GameObject transitionObject {
        get {
            switch (timeScale) {
                case TimeScale.Slower:
                    return slowedObject;
                case TimeScale.Normal:
                    return null;
                case TimeScale.Faster:
                    return forwardedObject;
                case TimeScale.Reverse:
                    return reversedObject;
            }
            throw new System.Exception("wtf: " + timeScale);
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
    private TimeScale sanitizedTimeScale;

    public AudioSource sfx { get; set; }

    private Dictionary<TimeScale, float> drags = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 10 },
        { TimeScale.Normal, 0.5f },
        { TimeScale.Reverse, 0.5f },
        { TimeScale.Faster, 0 }
    };

    private Dictionary<TimeScale, float> gravities = new Dictionary<TimeScale, float> {
        { TimeScale.Slower, 0.5f },
        { TimeScale.Normal, 1.0f },
        { TimeScale.Reverse, 1.0f },
        { TimeScale.Faster, 10.0f }
    };

    private new Rigidbody rigidbody;

    private Vector3 backupScale;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        backupScale = transform.localScale;
    }

    void FixedUpdate() {
        rigidbody.drag = drags[timeScale];
        rigidbody.AddForce(-Vector3.up * Physics.gravity.magnitude * gravities[timeScale]);
    }

    void LateUpdate() {
        if (transitionObject != null) {
            if(transitionTimer == 0.0f)
            {
                if (sfx != null)
                {
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
