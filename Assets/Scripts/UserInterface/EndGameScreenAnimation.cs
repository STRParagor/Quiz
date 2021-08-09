using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreenAnimation : MonoBehaviour
{
    [SerializeField] private Image _fadingImage;

    [SerializeField] private float _timeFadingToBlackScreen = 1f;
    [SerializeField] private float _timeFadingToLoadingScreen = 1f;
    [SerializeField] private float _timeUnfading = 1f;

    public void PlayFadeToBlack()
    {
        _fadingImage.color = new Color(0, 0, 0, 0);
        _fadingImage.gameObject.SetActive(true);
        _fadingImage.DOFade(1, _timeFadingToBlackScreen);
    }

    public void PlayFadeToLoadingScreen(TweenCallback onLoaded, TweenCallback onComplete)
    {
        _fadingImage.DOKill();

        Color imageColor = _fadingImage.color;
        imageColor.a = 1;

        _fadingImage.color = imageColor;

        Sequence sequenceAnimation = DOTween.Sequence();
        sequenceAnimation.Append(_fadingImage.DOColor(Color.white, _timeFadingToLoadingScreen).OnComplete(onLoaded));
        sequenceAnimation.Append(_fadingImage.DOFade(0, _timeUnfading).OnComplete(onComplete));

    }
}
