using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DeckBehaviour : MonoBehaviour
{

    [InlineEditor]
    public Deck deck;

    public void Start()
    {
        Shuffle();
    }

    [ContextMenu("Draw")]
    public void DrawCard()
    {
        deck.Draw();
    }

    [ContextMenu("Shuffle")]
    public void Shuffle()
    {
        deck.ShuffleDeck();
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        deck.Clear();
    }

    public void OnDestroy()
    {
        Clear();
    }


}
