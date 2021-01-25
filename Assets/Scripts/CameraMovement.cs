using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _dumping;
    [SerializeField] private Vector2 _speed = new Vector2(2f, 2f);
    [SerializeField] private float _focusTime;

    private Camera _camera;
    private Vector3 _targetPosition;
    private float _lastX;
    private bool _canMove = true;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _lastX = Mathf.RoundToInt(_target.position.x);

        _camera.transform.position = new Vector3(_target.position.x + _speed.x, _target.position.y + _speed.y, transform.position.z);
    }

    private void Update()
    {
        if(_canMove)
            SetPosition(SetDirection());
    }

    private Direction SetDirection()
    {
        int currentX = Mathf.RoundToInt(_target.position.x);

        if (currentX >= _lastX)
        {
            _lastX = Mathf.RoundToInt(_target.position.x);
            return Direction.Right;
        }
        else
        {
            _lastX = Mathf.RoundToInt(_target.position.x);
            return Direction.Left;
        }
    }

    private void SetPosition(Direction direction)
    {
        _targetPosition = new Vector3(_target.position.x + _speed.x * (int)direction, _target.position.y + _speed.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, _targetPosition, _dumping * Time.deltaTime);
        transform.position = currentPosition;
    }

    public void FosucOn(Obstackle obstackle)
    {
        Vector3 targetPosition = new Vector3(obstackle.transform.position.x, obstackle.transform.position.y, _camera.transform.position.z);
        _camera.transform.DOMove(targetPosition, _focusTime).SetLoops(1, LoopType.Yoyo).SetUpdate(true);
        StartCoroutine(FreezeTimer());
    }

    private IEnumerator FreezeTimer()
    {
        _canMove = false;

        int currentCount = (int)_focusTime;

        while (currentCount >= 0)
        {
            currentCount--;

            yield return new WaitForSeconds(1f);
        }
        _canMove = true;

    }

    private enum Direction
    {
        Left = -1,
        Right = 1
    }
}
