using TMPro;
using UnityEngine;

namespace SpaceCape {
    public class HUD : MonoBehaviour {
        public string itemText {
            set {
                transform.Find("ItemText").GetComponent<TextMeshProUGUI>().SetText(value);
            }
        }
        protected void Start() {
            itemText = "";
        }
    }
}