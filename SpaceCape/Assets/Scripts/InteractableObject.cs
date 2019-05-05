using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    public string label = "Testobjekt";

    public bool hasMerged { set; get; }

    private MoveController controller;
    private HUD hud;
    private bool displayLabel;

    void Start()
    {
        controller = FindObjectOfType<MoveController>();
        hud = FindObjectOfType<HUD>();
    }

    void Update()
    {
        if (displayLabel && controller.InRange(transform)) {
            hud.itemText = label;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!hasMerged) {
            collision.gameObject
                .GetComponents<InteractableObject>()
                .Where(interactable => ItemCombinationController.instance.TryToMerge(this, interactable))
                .Any();
        }
    }
    private void OnMouseOver() {
        displayLabel = true;
    }
    private void OnMouseExit() {
        if (displayLabel) {
            displayLabel = false;
            hud.itemText = "";
        }
    }
    private void OnDestroy() {
        OnMouseExit();
    }
}
