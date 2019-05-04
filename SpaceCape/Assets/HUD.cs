using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public string itemText {
        set {
            transform.Find("ItemText").GetComponent<TextMeshProUGUI>().SetText(value);
        }
    }
    void Start()
    {
        itemText = "";
    }
}
