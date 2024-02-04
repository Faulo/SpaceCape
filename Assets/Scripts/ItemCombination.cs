using System;
using UnityEngine;

namespace SpaceCape {
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
        public Vector3 CalculatePosition(InteractableObject a, InteractableObject b) {
            if (a.GetComponent<ImmoveableObject>()) {
                return a.transform.position;
            }

            if (b.GetComponent<ImmoveableObject>()) {
                return b.transform.position;
            }

            return (a.transform.position + b.transform.position) / 2;
        }
        public Quaternion CalculateRotation(InteractableObject a, InteractableObject b) {
            if (a.GetComponent<ImmoveableObject>()) {
                return a.transform.rotation;
            }

            if (b.GetComponent<ImmoveableObject>()) {
                return b.transform.rotation;
            }

            return Quaternion.Slerp(a.transform.rotation, b.transform.rotation, 0.5f);
        }
    }
}