using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField] private List<Switch> _switches;
    [SerializeField] private Sprite _imageOpen;
    [SerializeField] private Sprite _imageClose;

    private SpriteRenderer _spriteRenderer;
    private bool _isOpen = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckSwitchStatus();
    }

    private void CheckSwitchStatus()
    {
        int openedCount = 0;

        foreach (var switche in _switches)
        {
            if (switche.IsOpen == false)
            {
                Close();
                break;
            }
            else if (switche.IsOpen == true)
            {
                openedCount++;
            }
        }

        if (openedCount == _switches.Count)
        {
            Open();
        }
    }

    public void Open()
    {
        _isOpen = true;
        _spriteRenderer.sprite = _imageOpen;
    }

    public void Close()
    {
        _isOpen = false;
        _spriteRenderer.sprite = _imageClose;
    }

}
