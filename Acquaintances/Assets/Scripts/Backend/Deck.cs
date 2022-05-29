using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Deck", menuName = "Acquaintances/Deck", order = 3)]
public class Deck : ScriptableObject
{
    
    public List<Card> deck;

    [SerializeField]
    private List<Card> hand;

    public List<Card> Hand { get { return hand; } }

    [SerializeField]
    private List<Card> used;


    [ContextMenu("ShuffleDeck")]
    public void ShuffleDeck()
    {
        deck.Shuffle();
    }

    [ContextMenu("ShuffleHand")]
    public void ShuffleHand()
    {
        hand.Shuffle();
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        deck.AddRange(hand);
        deck.AddRange(used);

        hand.Clear();
        used.Clear();
    }

    [ContextMenu("Draw")]
    public void Draw()
    {
        if(deck.Count <= 0)
            return;
            
        hand.Add(deck[0]);
        deck.RemoveAt(0);
    }

    public void Draw(int amount)
    {
        for(int i = 0; i < amount; ++i)
            Draw();
    }

    public void Use(Card card)
    {
        if (!hand.Contains(card))
            return;

        hand.Remove(card);
        used.Add(card);
    }

    public void Reset()
    {
        Clear();
    }


}
