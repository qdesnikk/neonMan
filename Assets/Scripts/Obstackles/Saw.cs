using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Transform))]
public class Saw : Obstackle
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _playerLayer;

    private Transform _transform;
    private bool _isPlayerNear;
    private bool _isAtacking = false;
    private bool _isEnabled;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _transform.DORotate(new Vector3(0, 0, 360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
    }

    private void Update()
    {
        _isPlayerNear = Physics2D.OverlapCircle(_transform.position, _checkRadius, _playerLayer);

        if (_isEnabled)
            TrySwitch();
    }

    private void TrySwitch()
    {
            if (!_isAtacking && _isPlayerNear)
            {
                _isAtacking = true;
                _transform.DOMoveX(_transform.position.x - 3f, 1f);
                
            }
            else if (_isAtacking && !_isPlayerNear)
            {
                _isAtacking = false;
                _transform.DOMoveX(_transform.position.x + 3f, 1f);
                //_transform.DORotate(Vector3.zero, 0.1f);
            }
    }

    public override void Enable()
    {
        _isEnabled = true;
    }

    public override void Disable()
    {
        _isEnabled = false;
    }
}
