using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _steps;
    private int _currentStep = 0;

    private void OnEnable()
    {
        _currentStep = 0;
        foreach (var item in _steps)
        {
            item.SetActive(false);
        }
        _steps[_currentStep].SetActive(true);
    }

    public void GoToNextStep()
    {
        _currentStep++;
        foreach (var item in _steps)
        {
            item.SetActive(false);
        }
        _steps[_currentStep].SetActive(true);
    }

    public void GoToPreviousStep()
    {
        _currentStep--;
        foreach (var item in _steps)
        {
            item.SetActive(false);
        }
        _steps[_currentStep].SetActive(true);
    }

    public void HideLesson()
    {
        gameObject.SetActive(false);
    }

    public void ShowLesson()
    {
        gameObject.SetActive(true);
    }
}
