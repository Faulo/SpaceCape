using System.Linq;
using UnityEngine;

namespace SpaceCape {
    public class InteractableObject : MonoBehaviour {
        [SerializeField]
        public string label = "Testobjekt";

        public bool hasMerged { set; get; }

        MoveController controller;
        HUD hud;
        bool displayLabel;

        protected void Start() {
            controller = FindObjectOfType<MoveController>();
            hud = FindObjectOfType<HUD>();
        }

        protected void Update() {
            if (displayLabel && controller.InRange(transform)) {
                hud.itemText = label;
            }
        }

        protected void OnCollisionEnter(Collision collision) {
            if (!hasMerged) {
                collision.gameObject
                    .GetComponents<InteractableObject>()
                    .Where(interactable => ItemCombinationController.instance.TryToMerge(this, interactable))
                    .Any();
            }
        }
        protected void OnMouseOver() {
            displayLabel = true;
        }
        protected void OnMouseExit() {
            if (displayLabel) {
                displayLabel = false;
                hud.itemText = "";
            }
        }
        protected void OnDestroy() {
            OnMouseExit();
        }
    }
}