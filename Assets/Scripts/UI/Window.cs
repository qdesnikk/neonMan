using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Window : MonoBehaviour
{
    public virtual void OpenWindow()
    {
        this.gameObject.SetActive(true);
        this.transform.DOScale(1, 0.5f).From(0).SetUpdate(true);
        Time.timeScale = 0;
    }

    public virtual void CloseWindow()
    {
        this.transform.DOScale(0f, 0.5f).SetUpdate(true);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public virtual void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public virtual void RestartLevel()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        //int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int currentLevel = 1;
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
    }
}
