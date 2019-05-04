using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    public string label = "Testobjekt";

    public bool hasMerged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (hasMerged) {
            return;
        }
        collision.gameObject
            .GetComponents<InteractableObject>()
            .Where(interactable => ItemCombinationController.instance.TryToMerge(this, interactable))
            .Any();
    }
    private void OnMouseOver() {
        FindObjectOfType<HUD>().itemText = label;
    }
    private void OnMouseExit() {
        FindObjectOfType<HUD>().itemText = "";
    }
}
