using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class DisplayInfo : MonoBehaviour
{
    private void OnMouseOver()
    {
        FindObjectOfType<HUD>().itemText = GetComponent<InteractableObject>().label;
    }
    private void OnMouseExit()
    {
        FindObjectOfType<HUD>().itemText = "";
    }
}
