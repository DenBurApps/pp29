using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorSwaper : Theme
{
    [SerializeField] private Color _darkThemeColor;
    [SerializeField] private Color _lightThemeColor;
    [SerializeField] private Image _image;

    public override void SetDarkTheme()
    {
        _image.color = _darkThemeColor;
    }

    public override void SetLightTheme()
    {
        _image.color = _lightThemeColor;
    }
}
