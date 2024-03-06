using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerHand : MonoBehaviour
{
    private List<Card> _dealerCards = new List<Card>();
    public Action<int> CardAdded;

    public void AddCardToHand(Card card)
    {
        card.transform.parent = transform;
        _dealerCards.Add(card);
        int currentPoints = 0;
        int acesCount = 0;
        foreach (var item in _dealerCards)
        {
            currentPoints += item.GetCardValue();
            if (item.GetIsAce())
            {
                acesCount++;
            }
        }
        if (acesCount >= 2)
        {
            currentPoints -= (acesCount - 1) * 10;
        }
        if(_dealerCards.Count != 2)
        {
            CardAdded?.Invoke(currentPoints);
        }
    }

    public void RemoveCards()
    {
        foreach (var item in _dealerCards)
        {
            Destroy(item.gameObject);
        }
        _dealerCards.Clear();
    }

    public void RevealSecondCard()
    {
        _dealerCards[1].ShowCard();
        int currentPoints = 0;
        int acesCount = 0;
        foreach (var item in _dealerCards)
        {
            currentPoints += item.GetCardValue();
            if (item.GetIsAce())
            {
                acesCount++;
            }
        }
        if (acesCount >= 2)
        {
            currentPoints -= (acesCount - 1) * 10;
        }
        CardAdded?.Invoke(currentPoints);
    }

    public int GetCurrentScore()
    {
        int currentPoints = 0;
        int acesCount = 0;
        foreach (var item in _dealerCards)
        {
            currentPoints += item.GetCardValue();
            if (item.GetIsAce())
            {
                acesCount++;
            }
        }
        if (acesCount >= 2)
        {
            currentPoints -= (acesCount - 1) * 10;
        }
        return currentPoints;
    }
}
