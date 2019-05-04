using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class DisplayInfo : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI infoText;
    public String labelText;

    // Start is called before the first frame update
    void Start()
    {
        infoText.SetText("");
        labelText = GetComponent<InteractableObject>().label;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        infoText.SetText(labelText);
    }
    private void OnMouseExit()
    {
        infoText.SetText("");
    }
}
