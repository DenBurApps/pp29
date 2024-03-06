using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteButton : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private Image _image;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _likedColor;

    private void OnEnable()
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        if (fav.Items[_index])
        {
            _image.color = _likedColor;
        }
        else
        {
            _image.color = _defaultColor;
        }
    }

    public void AddToFavorites()
    {
        _image.color = _likedColor;
    }

    public void RemoveFromFavorites()
    {
        _image.color = _defaultColor;
    }
}
