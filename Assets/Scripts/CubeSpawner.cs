using UnityEngine;

namespace SpaceCape {
    public class CubeSpawner : MonoBehaviour {
        [SerializeField]
        GameObject cubePrefab;

        [SerializeField]
        float spawnRate = 1;

        float spawnTimer;

        // Start is called before the first frame update
        protected

        // Start is called before the first frame update
        void Start() {
            spawnTimer = spawnRate;
        }

        // Update is called once per frame
        protected

        // Update is called once per frame
        void Update() {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0) {
                spawnTimer += spawnRate;
                Instantiate(cubePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(1000 * Vector3.down);
            }
        }
    }
}