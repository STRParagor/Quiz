using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

abstract public class Grid : MonoBehaviour, IRestart
{
    [SerializeField] protected GridLayoutGroup _gridLayout;
    protected List<Card> _cardsInGrid = new List<Card>();

    public GridLayoutGroup GridLayout { get => _gridLayout; }
    public List<Card> CardsInGrid{ get => _cardsInGrid; }

    public void Restart()
    {
        Clear();
        Fill();
    }

    abstract protected void Clear();
    abstract protected void Fill();
}
