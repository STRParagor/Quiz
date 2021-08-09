using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour, ISpawnerGrid
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private CardBundle _cardBundle;
    [SerializeField] private CheckCorrectAnswer _checkCorrectAnswer;

    public void Spawn(Grid grid, int spawnCount)
    {
        List<CardData> total = _cardBundle.CurrentCardBundleData.Cards.OneOrMoreOf(spawnCount);

        for (int i = 0; i < total.Count; i++)
        {
            Card card = Instantiate(_cardPrefab, grid.transform);

            _checkCorrectAnswer.DisableInputEvent.AddListener(card.DisableInput);
            card.Init(total[i], _checkCorrectAnswer);
            grid.CardsInGrid.Add(card);
        }
    }
}

