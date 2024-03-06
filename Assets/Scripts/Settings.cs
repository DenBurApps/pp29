using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private string _email;
    [SerializeField] private GameObject _privacy;
    [SerializeField] private GameObject _terms;
    [SerializeField] private ThemeSwaper _themeSwaper;

    public void ContactWithDeveloper()
    {
        Application.OpenURL("mailto:" + _email + "?subject=Mail to developer");
    }

    public void ShowTerms()
    {
        _terms.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowPrivacy()
    {
        _privacy.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SwapTheme()
    {
        var settings = SaveSystem.LoadData<SettingSaveData>();
        if (settings.IsDark)
        {
            settings.IsDark = false;
            _themeSwaper.SwapToLightTheme();           
        }
        else
        {
            settings.IsDark = true;
            _themeSwaper.SwapToDarkTheme();
        }
        SaveSystem.SaveData(settings);
    }

}
