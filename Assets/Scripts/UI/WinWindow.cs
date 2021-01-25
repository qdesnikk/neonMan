using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : Window
{
    [SerializeField] private Player _player;
    [SerializeField] private LevelChanger _levelChanger;

    private void OnEnable()
    {
        _player.EnteredTheDoor += OpenWindow;
    }

    private void OnDisable()
    {
        _player.EnteredTheDoor -= OpenWindow;
    }

    public void TryLoadNextLevel()
    {
        _levelChanger.OpenNextLevel();
    }

}
