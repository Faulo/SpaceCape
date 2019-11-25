using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickReplace : MonoBehaviour {
    [SerializeField]
    private GameObject replacementObject;

    void OnMouseDown()
    {
        Instantiate(replacementObject, transform.position, replacementObject.transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
