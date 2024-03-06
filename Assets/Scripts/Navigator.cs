using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _canvases;
    [SerializeField] private List<GameObject> _setImages;

    private void Awake()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        foreach (var item in _canvases)
        {
            item.SetActive(false);
        }
        _canvases[0].SetActive(true);
        foreach (var item in _setImages)
        {
            item.SetActive(false);
        }
        _setImages[0].SetActive(true);
    }

    public void ShowTips()
    {
        foreach (var item in _canvases)
        {
            item.SetActive(false);
        }
        _canvases[1].SetActive(true);
        foreach (var item in _setImages)
        {
            item.SetActive(false);
        }
        _setImages[1].SetActive(true);
    }

    public void ShowFavorites()
    {
        foreach (var item in _canvases)
        {
            item.SetActive(false);
        }
        _canvases[2].SetActive(true);
        foreach (var item in _setImages)
        {
            item.SetActive(false);
        }
        _setImages[2].SetActive(true);
    }

    public void ShowSettings()
    {
        foreach (var item in _canvases)
        {
            item.SetActive(false);
        }
        _canvases[3].SetActive(true);
        foreach (var item in _setImages)
        {
            item.SetActive(false);
        }
        _setImages[3].SetActive(true);
    }
}
