using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private int _levelsCount;
    private int _currentLevel;

    private void Start()
    {
        _levelsCount = PlayerPrefs.GetInt("LevelsCount"); ;
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    public void OpenNextLevel()
    {
        if (_levelsCount >= _currentLevel + 1)
        {
            _currentLevel++;
            PlayerPrefs.SetInt("CurrentLevel", _currentLevel);

            TryUnlockNextLevel();

            SceneManager.LoadScene(_currentLevel, LoadSceneMode.Single);
            Time.timeScale = 1;
        }
    }

    private void TryUnlockNextLevel()
    {
        int totalCountUnlockedLevels = PlayerPrefs.GetInt("TotalCountUnlockedLevels");

        if (totalCountUnlockedLevels < _currentLevel)
        {
            totalCountUnlockedLevels++;
            PlayerPrefs.SetInt("TotalCountUnlockedLevels", totalCountUnlockedLevels);
        }
    }
}
