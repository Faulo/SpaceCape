using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCombination {
    public InteractableObject sourceItem;
    public InteractableObject combinedWith;
    public InteractableObject resultsIn;

    public bool isValid {
        get {
            return !(sourceItem == null || combinedWith == null || resultsIn == null);
        }
    }
}
