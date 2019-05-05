using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Light))]
public class ToggleableLight : MonoBehaviour
{
    public void TurnOn() {
        GetComponent<Light>().enabled = true;
    }
    public void TurnOff() {
        GetComponent<Light>().enabled = false;
    }
}
