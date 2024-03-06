using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] private TMP_Text _letter;
    [SerializeField] private TMP_Text _answer;
    [SerializeField] private Button _button;
    [SerializeField] private Image _correctImage;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _wrongColor;

    private int _index;

    public Action<int> AnswerChoosed;

    public void Init(char letter, string answer, int index)
    {
        _letter.text = letter.ToString();
        _answer.text = answer;
        _index = index;
        _button.onClick.AddListener(OnAnswerButtonClicked);
    }

    public void DeactiveButton()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void ShowCorrect()
    {
        _correctImage.color = _correctColor;
        _correctImage.gameObject.SetActive(true);
    }

    public void ShowWrong()
    {
        _correctImage.color = _wrongColor;
        _correctImage.gameObject.SetActive(true);
    }

    private void OnAnswerButtonClicked() 
    {
        AnswerChoosed?.Invoke(_index);
    }

}
