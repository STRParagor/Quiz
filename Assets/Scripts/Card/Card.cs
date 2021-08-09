using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _cardImage;
    [SerializeField] private CardEffects _cardEffects;

    public bool IsCorrect { get => _isCorrect; set => _isCorrect = value; }
    public CardData CardData { get => _cardData; }

    
    private bool _isCorrect = false;
    private CardData _cardData;
    private ICorrectAnswer _correctAnswer;

    /// <summary>
    /// Card initialization on creation
    /// </summary>
    public void Init(CardData cardData, ICorrectAnswer correctAnswer)
    {
        _cardData = cardData;
        _correctAnswer = correctAnswer;
        _cardImage.sprite = _cardData.Sprite;
        _cardImage.transform.localEulerAngles = new Vector3(0,0, _cardData.SpriteAngle);
        _cardEffects.PlayEnableCards();
    }

    /// <summary>
    /// Disable the ability to click on the card
    /// </summary>
    public void DisableInput()
    {
        _backgroundImage.raycastTarget = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isCorrect)
        {
            _correctAnswer.OnBeforeAnimCorrectAnswer();
            _cardEffects.PlayCorrectCard(() =>
            {
                _correctAnswer.OnAfterAnimCorrectAnswer();
            });
        }
        else
        {
            _cardEffects.PlayWrongCard();
        }
    }

}
