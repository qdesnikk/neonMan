﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsWindow : Window
{
    [SerializeField] private List<LevelButton> _levelButtons;

    private int _totalCountUnlockedLevels = 1;

    private void Awake()
    {
        PlayerPrefs.SetInt("LevelsCount", _levelButtons.Count);

        //PlayerPrefs.SetInt("TotalCountUnlockedLevels", 1);
        if (!PlayerPrefs.HasKey("TotalCountUnlockedLevels"))
            PlayerPrefs.SetInt("TotalCountUnlockedLevels", 1);
    }

    private void Start()
    {
        _totalCountUnlockedLevels = PlayerPrefs.GetInt("TotalCountUnlockedLevels");

        for (int i = 0; i < _totalCountUnlockedLevels; i++)
        {
            _levelButtons[i].Unlock();
        }
    }
}

