using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _physicsMovement;

    private Transform _transform;
    private Animator _animator;
    private PlayerInput _input;
    private bool _isFacedRight = true;

    private bool _isGrounded => _physicsMovement.IsGrounded;
    private bool _isDirectionRight => _physicsMovement.TargetVelocity > 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();

        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Move.performed += ctx => Run();
        _input.Player.Jump.performed += ctx => Jump();
    }

    private void Update()
    {
        if (!_isDirectionRight && _isFacedRight)
        {
            Flip();
        }
        else if (_isDirectionRight && !_isFacedRight)
        {
            Flip();
        }

        if(_physicsMovement.TargetVelocity == 0 && _isGrounded)
            _animator.Play("Stay");
    }

    private void Flip()
    {
        _isFacedRight = !_isFacedRight;
        Vector3 tempScale = _transform.localScale;
        tempScale.x *= -1;
        _transform.localScale = tempScale;
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _animator.Play("StartJump");
        }
    }
    private void Run()
    {
        if (_isGrounded)
        {
            _animator.Play("StartRun");
        }
    }
}
