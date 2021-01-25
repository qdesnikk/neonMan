using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Transform))]
public class Spikes : Obstackle
{
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    private Transform _transform;
    private float _startPositionY;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _startPositionY = _transform.position.y;
    }

    public override void Enable()
    {
        _transform.DOPause();
        _transform.DOMoveY(_transform.position.y + _range, _speed).SetLoops(-1, LoopType.Yoyo);
    }

    public override void Disable()
    {
        _transform.DOPause();
        _transform.DOMoveY(_startPositionY, _speed);
    }

}
