using UnityEngine;

namespace SpaceCape {
    public class MoveableObject : MonoBehaviour {
        MoveController controller;

        bool pickedUp = false;

        // Start is called before the first frame update
        protected

        // Start is called before the first frame update
        void Start() {
            controller = FindObjectOfType<MoveController>();
        }

        protected void OnMouseDown() {
            if (controller.InRange(transform)) {
                controller.Pickup(this);
                pickedUp = true;
            }
        }

        protected void OnMouseUp() {
            if (pickedUp) {
                controller.Drop();
            }
        }
        protected void OnDestroy() {
            OnMouseUp();
        }
    }
}