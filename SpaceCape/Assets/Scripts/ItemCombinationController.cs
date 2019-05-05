using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemCombinations", menuName = "Gameplay/Item Combinations", order = 1)]
public class ItemCombinationController : ScriptableObject {
    public static ItemCombinationController instance {
        get {
            return Resources.Load<ItemCombinationController>("ItemCombinations");
        }
    }
    [SerializeField]
    private ItemCombination[] itemCombinations;

    public bool TryToMerge(InteractableObject a, InteractableObject b) {
        return itemCombinations
            .Where(combination => combination.isValid)
            .Where(combination =>
                   combination.sourceItem.label == a.label && combination.combinedWith.label == b.label
                || combination.sourceItem.label == b.label && combination.combinedWith.label == a.label
            )
            .Any(combination => {
                var sourceItem = combination.sourceItem.label == a.label
                    ? a
                    : b;
                Vector3 position;
                Quaternion rotation;

                if (combination.isStationary) {
                    position = sourceItem.transform.position;
                    rotation = sourceItem.transform.rotation;
                } else {
                    position = (a.transform.position + b.transform.position) / 2;
                    rotation = Quaternion.Slerp(a.transform.rotation, b.transform.rotation, 0.5f);
                }

                var c = Instantiate(combination.resultsIn, position, rotation);

                a.hasMerged = true;
                b.hasMerged = true;
                Destroy(a.gameObject);
                Destroy(b.gameObject);
                
                return true;
            });
    }
}
