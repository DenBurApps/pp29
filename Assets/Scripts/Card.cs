using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private GameObject _hideImage;
    [SerializeField] private bool _isAce;

    public void HideCard()
    {
        _hideImage.SetActive(true);
    }

    public void ShowCard()
    {
        _hideImage.SetActive(false);
    }

    public int GetCardValue()
    {
        return _value;
    }

    public bool GetIsAce()
    {
        return _isAce;
    }
}
