using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardEffects : MonoBehaviour
{
    [SerializeField] private RectTransform _backgroundTransform;
    [SerializeField] private RectTransform _spriteTransform;

    [SerializeField] private AnimationCurve _enableCardCurve;
    [SerializeField] private AnimationCurve _disableCardCurve;
    [SerializeField] private float _timeEnableAnimation = 1f;
    [SerializeField] private float _timeDisableAnimation = 0.5f;

    [SerializeField] private float _timeWrongShake = 2f;

    /// <summary>
    /// Reset transform and kill animation from DOTweeker
    /// </summary>
    private void ResetTranform()
    {
        _backgroundTransform.DOKill();

        _backgroundTransform.localPosition = Vector3.zero;
        _backgroundTransform.localScale = Vector3.one;
    }

    /// <summary>
    /// Play bounce animation when cards is created
    /// </summary>
    public void PlayEnableCards()
    {
        ResetTranform();

        _backgroundTransform.localScale = Vector3.zero;
        _backgroundTransform.DOScale(1, _timeEnableAnimation).SetEase(_enableCardCurve); ;
    }

    /// <summary>
    /// Play animation when choosing the wrong card
    /// </summary>
    public void PlayWrongCard()
    {
        ResetTranform();

        _backgroundTransform.DOShakePosition(_timeWrongShake, 10f, 10, 90f);
    }

    /// <summary>
    /// Play animation when choosing the correct card
    /// </summary>
    /// <param name="onCompleteAnimation">Callback when animation ends</param>
    public void PlayCorrectCard(TweenCallback onCompleteAnimation )
    {
        ResetTranform();

        _spriteTransform.localScale = Vector3.one;
        _spriteTransform.DOScale(0, _timeDisableAnimation).SetEase(_disableCardCurve).OnComplete(onCompleteAnimation); 
    }
}
