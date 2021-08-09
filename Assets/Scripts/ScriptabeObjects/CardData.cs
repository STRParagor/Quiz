using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    [SerializeField] private Sprite _sprite;

    [Range(0, 360)]
    [SerializeField] private float _spriteAngle;

    [SerializeField] private string _identifier;


    public Sprite Sprite { get => _sprite; }
    public float SpriteAngle { get => _spriteAngle; }
    public string Identifier { get => _identifier; }

}
