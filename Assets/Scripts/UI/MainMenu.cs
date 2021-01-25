using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartPlay()
    {
        //int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int currentLevel = 1;
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
    }

    public void OpenWindow(Window window)
    {
        window.gameObject.SetActive(true);
        window.transform.DOScale(1, 0.5f).From(0).SetUpdate(true);
        Time.timeScale = 0;
    }

    public void CloseWindow(Window window)
    {
        window.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
