using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    private MoveController controller;

    // Start is called before the first frame update
    void Start() {
        controller = FindObjectOfType<MoveController>();
    }

    private void OnMouseDown() {
        if (controller.InRange(transform)) {
            controller.Pickup(this);
        }
    }

    private void OnMouseUp() {
        controller.Drop();
    }
}
