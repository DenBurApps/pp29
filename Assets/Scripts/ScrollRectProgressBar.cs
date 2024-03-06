using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _percentage;
    [SerializeField] private float _maxPos;


    private void Update()
    {
        
        Debug.Log(_content.anchoredPosition.y);
        float fill = _content.anchoredPosition.y / _maxPos;
        Debug.Log(fill);
        _progressBar.fillAmount = fill;
        int percentage = (int)(fill * 100);
        if(percentage >= 100)
        {
            percentage = 100;
        }
        _percentage.text = percentage + "%";
    }

}
