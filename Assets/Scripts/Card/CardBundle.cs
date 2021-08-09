using UnityEngine;

public class CardBundle : MonoBehaviour
{
    [SerializeField] private CardBundleData[] _cardBundles;

    private CardBundleData _currentCardBundleData;
    public CardBundleData CurrentCardBundleData { get => _currentCardBundleData; }

    public void SetRandomCardBundle()
    {
        _currentCardBundleData = _cardBundles[Random.Range(0, _cardBundles.Length)];
    }

}
