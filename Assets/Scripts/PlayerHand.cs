using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private List<Card> _playerCards = new List<Card>();
    public Action<int> CardAdded;

    public void AddCardToHand(Card card)
    {
        card.transform.parent = transform;
        _playerCards.Add(card);
        card.ShowCard();
        int currentPoints = 0;
        int acesCount = 0;
        foreach (var item in _playerCards)
        {
            currentPoints += item.GetCardValue();
            if (item.GetIsAce())
            {
                acesCount++;
            }
        }
        if(acesCount >= 2)
        {
            currentPoints -= (acesCount - 1) * 10;
        }
        CardAdded?.Invoke(currentPoints);
    }

    public void RemoveCards()
    {
        foreach (var item in _playerCards)
        {
            Destroy(item.gameObject);
        }
        _playerCards.Clear();
    }

    public int GetCurrentScore()
    {
        int currentPoints = 0;
        int acesCount = 0;
        foreach (var item in _playerCards)
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
