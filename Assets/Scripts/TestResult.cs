using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestResult : MonoBehaviour
{
    [SerializeField] private GameObject _resultCanvas;
    [SerializeField] private TMP_Text _answers;
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Color _goodColor;
    [SerializeField] private Color _badColor;
    [SerializeField] private string _goodResult;
    [SerializeField] private string _goodDescription;
    [SerializeField] private string _badResult;
    [SerializeField] private string _badDescription;

    public void ShowResult(int correctAnswers, int questionsCount)
    {
        _answers.text = correctAnswers + "/" + questionsCount;
        _progressBar.fillAmount = (float)correctAnswers / questionsCount;
        if (correctAnswers > questionsCount / 2)
        {
            _progressBar.color = _goodColor;
            _resultText.text = _goodResult;
            _description.text = _goodDescription;
        }
        else
        {
            _progressBar.color = _badColor;
            _resultText.text = _badResult;
            _description.text = _badDescription;
        }
        _resultCanvas.SetActive(true);
    }
}
