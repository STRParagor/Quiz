using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "Game/Card Bundle Data", order = 1)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private List<CardData> _cards;

    public List<CardData> Cards { get => _cards; }
}
