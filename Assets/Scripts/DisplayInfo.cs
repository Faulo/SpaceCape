using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class DisplayInfo : MonoBehaviour {
    protected void OnMouseOver() {
        FindObjectOfType<HUD>().itemText = GetComponent<InteractableObject>().label;
    }
    protected void OnMouseExit() {
        FindObjectOfType<HUD>().itemText = "";
    }
}
