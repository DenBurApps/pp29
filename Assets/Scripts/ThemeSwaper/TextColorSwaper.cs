using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorSwaper : Theme
{
    [SerializeField] private Color _darkThemeColor;
    [SerializeField] private Color _lightThemeColor;
    [SerializeField] private TMP_Text _text;

    public override void SetLightTheme()
    {
        _text.color = _lightThemeColor;
    }

    public override void SetDarkTheme()
    {
        _text.color = _darkThemeColor;
    }
}
