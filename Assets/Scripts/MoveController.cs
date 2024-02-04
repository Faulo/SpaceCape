using SpaceCape.Extensions;
using UnityEngine;

namespace SpaceCape {
    public class MoveController : MonoBehaviour {
        [SerializeField]
        float range = 3;

        Transform guide;
        MoveableObject item;
        // Start is called before the first frame update
        protected
        // Start is called before the first frame update
        void Start() {
            guide = transform.GetChild(0).Find("Carry");
        }

        // Update is called once per frame
        protected

        // Update is called once per frame
        void Update() {

        }

        public bool InRange(Transform t) {
            return Vector3.Distance(transform.position, t.position) < range;
        }

        public void Pickup(MoveableObject newItem) {
            if (item != null) {
                Drop();
            }

            item = newItem;
            item.GetComponents<Rigidbody>()
                .ForAll(body => {
                    body.useGravity = false;
                    body.isKinematic = true;
                });
            item.transform.parent = guide;
        }
        public void Drop() {
            if (item != null) {
                if (item.isActiveAndEnabled) {
                    item.GetComponents<Rigidbody>()
                    .ForAll(body => {
                        body.useGravity = true;
                        body.isKinematic = false;
                    });
                    item.transform.parent = transform.parent;
                    item = null;
                }
            }
        }
    }
}