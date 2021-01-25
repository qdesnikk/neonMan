using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Switch : MonoBehaviour
{
    [SerializeField] private Sprite _open;
    [SerializeField] private Sprite _close;
    [SerializeField] private Obstackle _obstackle;
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private ParticleSystem _particleSystem;

    private SpriteRenderer _spriteRenderer;
    private bool _isOpen;
    private bool _isUsed = false;

    public bool IsOpen => _isOpen;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Close();
    }

    private void Open()
    {
        _isOpen = true;
        _spriteRenderer.sprite = _open;
        _obstackle.Disable();
        _particleSystem.Play();
    }

    private void Close()
    {
        _isOpen = false;
        _spriteRenderer.sprite = _close;
        _obstackle.Enable();
        _particleSystem.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if(_isUsed == false)
            {
                _camera.FosucOn(_obstackle);
                _isUsed = true;
            }
        }
        else if ( collision.gameObject.TryGetComponent(out Thing thing))
        {
            Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thing thing))
        {
            Close();
            Debug.Log("close_switch");
        }
    }
}
