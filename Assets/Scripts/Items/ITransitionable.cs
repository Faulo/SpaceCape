using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransitionable {
    void OnReverse();
    void OnForward();
    void OnSlower();
}
