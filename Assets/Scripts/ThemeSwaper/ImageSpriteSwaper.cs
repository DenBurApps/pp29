using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpriteSwaper : Theme
{
    [SerializeField] private Sprite _darkTheme;
    [SerializeField] private Sprite _lightTheme;
    [SerializeField] private Image _image;

    public override void SetLightTheme()
    {
        _image.sprite = _lightTheme;
    }

    public override void SetDarkTheme()
    {
        _image.sprite = _darkTheme;
    }
}
