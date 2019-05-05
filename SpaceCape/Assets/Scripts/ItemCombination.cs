using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCombination {
    public InteractableObject sourceItem;
    public InteractableObject combinedWith;
    public InteractableObject resultsIn;

    public bool isValid {
        get {
            return !(sourceItem == null || combinedWith == null || resultsIn == null);
        }
    }
    public Vector3 resultPosition {
        get {
            if (sourceItem.GetComponent<ImmoveableObject>()) {
                return sourceItem.transform.position;
            }
            if (combinedWith.GetComponent<ImmoveableObject>()) {
                return combinedWith.transform.position;
            }
            return (sourceItem.transform.position + combinedWith.transform.position) / 2;
        }
    }
    public Quaternion resultRotation {
        get {
            if (sourceItem.GetComponent<ImmoveableObject>()) {
                return sourceItem.transform.rotation;
            }
            if (combinedWith.GetComponent<ImmoveableObject>()) {
                return combinedWith.transform.rotation;
            }
            return Quaternion.Slerp(sourceItem.transform.rotation, combinedWith.transform.rotation, 0.5f);
        }
    }
}
