using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ObjectiveEffects : MonoBehaviour
{
    [SerializeField] private float _timeFade = 1f;


    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        Fade(true);
    }

    public void Fade(bool fadeIn)
    {
        Color color = _text.color;
        color.a = fadeIn ? 0 : 1;

        _text.color = color;
        _text.DOFade(fadeIn ? 1 : 0, _timeFade);
    }
}
