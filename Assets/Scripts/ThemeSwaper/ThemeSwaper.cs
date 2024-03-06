using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSwaper : MonoBehaviour
{
    public List<Theme> _elements;


    private void Awake()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        if (settings.IsDark)
        {
            SwapToDarkTheme();
        }
        else
        {
            SwapToLightTheme();
        }
    }

    public void SwapToDarkTheme()
    {
        foreach (var item in _elements)
        {
            item.SetDarkTheme();
        }
    }

    public void SwapToLightTheme()
    {
        foreach (var item in _elements)
        {
            item.SetLightTheme();
        }
    }
}
