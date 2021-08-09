using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private ObjectiveEffects _objectiveEffects;

    public ObjectiveEffects Effects { get => _objectiveEffects; }

    public void SetObjective(CardData cardData)
    {
        _text.text = "Find: " + cardData.Identifier;
    }
}
