using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<LessonController> _lessons;
    [SerializeField] private GameObject _mainMenuCanvas;

    public void StartLesson(int index)
    {
        _lessons[index].ShowLesson();
        _mainMenuCanvas.SetActive(false);
    }

    public void PlayBlackjack()
    {
        SceneManager.LoadScene("Blackjack");
    }

}
