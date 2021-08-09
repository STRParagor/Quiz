using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Grid _baseGrid;
    [SerializeField] private int[] _cardsCountPerLevel;
    [SerializeField] private CardBundle _cardBundle;
    [SerializeField] private Objective _objective;

    [SerializeField] private EndGameScreen _endGameScreen;

    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    public int[] CardsCountPerLevel { get => _cardsCountPerLevel; }
    public CardBundle CardBundle { get => _cardBundle; }
    public EndGameScreen EndGameScreen { get => _endGameScreen; }
    public Grid BaseGrid { get => _baseGrid; }
    public UnityEvent DisableInputEvent { get => _disableInputEvent; }

    private int _currentLevel;
    private ISpawnerGrid _spawnerGrid;
    private UnityEvent _disableInputEvent = new UnityEvent();
    private List<CardData> _usedCards = new List<CardData>();


    private void Start()
    {
        if (_cardsCountPerLevel.Length < 1)
            throw new System.Exception("The number of cards on the levels is not set");

        _spawnerGrid = GetComponent<ISpawnerGrid>();

        if (_spawnerGrid == null)
            throw new System.Exception("Spawner is not assigned in the inspector for the grid");

        _baseGrid.Restart();
    }

    public void Generate()
    {
        _cardBundle.SetRandomCardBundle();
        _spawnerGrid.Spawn(_baseGrid, _cardsCountPerLevel[_currentLevel]);
        SetRandomCorrectCard();
    }

    private void SetRandomCorrectCard()
    {
        int randomIndex = Random.Range(0, _baseGrid.CardsInGrid.Count);
        CardData cardData = _baseGrid.CardsInGrid[randomIndex].CardData;

        foreach (CardData item in _usedCards)
        {
            randomIndex = Random.Range(0, _baseGrid.CardsInGrid.Count);
            cardData = _baseGrid.CardsInGrid[randomIndex].CardData;

            if (!_usedCards.Contains(cardData))
            {
                break;
            }
        }

        _usedCards.Add(cardData);
        _baseGrid.CardsInGrid[randomIndex].IsCorrect = true;
        _objective.SetObjective(cardData);
    }
}
