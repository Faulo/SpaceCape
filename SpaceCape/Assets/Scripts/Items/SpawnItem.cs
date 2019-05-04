using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {
    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private int itemAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (itemPrefab != null) {
            for (int i = 0; i < itemAmount; i++) {
                Instantiate(itemPrefab, transform.position, transform.rotation)
                    .GetComponents<Rigidbody>()
                    .ForAll(body => body.AddForce(Physics.gravity.magnitude * Vector3.up));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
