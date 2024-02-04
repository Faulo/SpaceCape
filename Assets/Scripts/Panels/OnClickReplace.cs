using UnityEngine;

public class OnClickReplace : MonoBehaviour {
    [SerializeField]
    GameObject replacementObject;

    protected void OnMouseDown() {
        Instantiate(replacementObject, transform.position, replacementObject.transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
