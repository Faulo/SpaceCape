using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {
    private MoveController controller;
    // Start is called before the first frame update
    void Start() {
        controller = FindObjectOfType<MoveController>();
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnMouseDown() {
        Debug.Log(this);
        controller.Pickup(this);
    }
    private void OnMouseUp() {
        controller.Drop();
    }
}
