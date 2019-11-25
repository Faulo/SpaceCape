using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    private MoveController controller;

    private bool pickedUp = false;

    // Start is called before the first frame update
    void Start() {
        controller = FindObjectOfType<MoveController>();
    }

    private void OnMouseDown() {
        if (controller.InRange(transform)) {
            controller.Pickup(this);
            pickedUp = true;
        }
    }

    public void OnMouseUp() {
        if (pickedUp) {
            controller.Drop();
        }
    }
    private void OnDestroy() {
        OnMouseUp();
    }
}
