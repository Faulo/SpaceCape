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
    ItemCombination[] itemCombinations;

    public bool TryToMerge(InteractableObject a, InteractableObject b) {
        return itemCombinations
            .Where(combination => combination.isValid)
            .Where(combination =>
                   (combination.sourceItem.label == a.label && combination.combinedWith.label == b.label)
                || (combination.sourceItem.label == b.label && combination.combinedWith.label == a.label)
            )
            .Any(combination => {
                var c = Instantiate(combination.resultsIn, combination.CalculatePosition(a, b), combination.CalculateRotation(a, b));

                a.hasMerged = true;
                b.hasMerged = true;
                Destroy(a.gameObject);
                Destroy(b.gameObject);

                return true;
            });
    }
}
