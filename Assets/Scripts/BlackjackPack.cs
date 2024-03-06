using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BlackjackPack : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private DealerHand _dealerHand;
    private IEnumerator _giveCards;
    private List<Card> _currentCards = new List<Card>();

    public Action StartCardsDealed;
    public Action PlayerGetCard;
    public Action DealerGetCard;

    public void StartGame()
    {
        _currentCards.Clear();
        foreach (var item in _cards)
        {
            _currentCards.Add(item);
        }
        Shuffle(_currentCards);
        GiveStartCards();
    }

    public void GiveStartCards()
    {
        if(_giveCards != null)
        {
            StopCoroutine(_giveCards);
            _giveCards = null;
        }
        _giveCards = GiveCards();
        StartCoroutine(_giveCards);
        
    }

    private IEnumerator GiveCards()
    {
        Card card = Instantiate(_currentCards[0], transform);
        card.HideCard();
        _currentCards.RemoveAt(0);
        card.transform.DOMove(_playerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject);
        yield return new WaitForSeconds(1f);
        _playerHand.AddCardToHand(card);
        Card card2 = Instantiate(_currentCards[0], transform);
        card2.HideCard();
        _currentCards.RemoveAt(0);
        card2.transform.DOMove(_dealerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject);
        yield return new WaitForSeconds(1f);
        _dealerHand.AddCardToHand(card2);
        card2.ShowCard();
        Card card3 = Instantiate(_currentCards[0], transform);
        card3.HideCard();
        _currentCards.RemoveAt(0);
        card3.transform.DOMove(_playerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject);
        yield return new WaitForSeconds(1f);
        _playerHand.AddCardToHand(card3);
        Card card4 = Instantiate(_currentCards[0], transform);
        card4.HideCard();
        _currentCards.RemoveAt(0);
        card4.transform.DOMove(_dealerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject);
        yield return new WaitForSeconds(1f);
        _dealerHand.AddCardToHand(card4);
        StartCardsDealed?.Invoke();
    }

    public void GiveCardToPlayer()
    {
        Card card = Instantiate(_currentCards[0], transform);
        card.HideCard();
        _currentCards.RemoveAt(0);
        card.transform.DOMove(_playerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject).OnComplete(() => 
        {
            _playerHand.AddCardToHand(card);
            PlayerGetCard?.Invoke();
        });

    }

    public void GiveCardToDealer()
    {
        Card card = Instantiate(_currentCards[0], transform);
        card.HideCard();
        _currentCards.RemoveAt(0);
        card.transform.DOMove(_dealerHand.transform.position, 1f).SetEase(Ease.Linear).SetLink(gameObject).OnComplete(() =>
        {
            _dealerHand.AddCardToHand(card);
            card.ShowCard();
            PlayerGetCard?.Invoke();
        });
    }

    private void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

