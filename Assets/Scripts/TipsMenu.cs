using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsMenu : MonoBehaviour
{
    [SerializeField] private List<LessonController> _tips;
    [SerializeField] private GameObject _tipsMenuCanvas;

    public void StartLesson(int index)
    {
        _tips[index].ShowLesson();
        _tipsMenuCanvas.SetActive(false);

    }
}
