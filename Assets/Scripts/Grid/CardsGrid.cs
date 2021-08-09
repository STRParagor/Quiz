using UnityEngine;

public class CardsGrid : Grid
{
    [SerializeField] private LevelGenerator _levelGenerator;

    protected override void Clear()
    {
        _levelGenerator.DisableInputEvent.RemoveAllListeners();

        foreach (Card card in _cardsInGrid)
            Destroy(card.gameObject);

        _cardsInGrid.Clear();
    }

    protected override void Fill()
    {
        _levelGenerator.Generate();
    }

}
