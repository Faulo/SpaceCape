using SpaceCape.Extensions;
using UnityEngine;

namespace SpaceCape.Items {
    public class SpawnItem : MonoBehaviour {
        [SerializeField]
        GameObject itemPrefab;

        [SerializeField]
        int itemAmount = 1;

        // Start is called before the first frame update
        protected

        // Start is called before the first frame update
        void Start() {
            if (itemPrefab != null) {
                for (int i = 0; i < itemAmount; i++) {
                    Instantiate(itemPrefab, transform.position, transform.rotation)
                        .GetComponents<Rigidbody>()
                        .ForAll(body => body.AddForce(Physics.gravity.magnitude * Vector3.up));
                }
            }
        }

        // Update is called once per frame
        protected

        // Update is called once per frame
        void Update() {

        }
    }
}