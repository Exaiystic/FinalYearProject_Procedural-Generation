using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Settings - Movement")]
    [SerializeField] private float _combatSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _smoothSpeed = 0.1f;

    [Header("Settings - Dash")]
    [SerializeField] private GameObject _dashSystem;
    [SerializeField] private float _dashForce = 50f;
    [SerializeField] private float _dashTime = 0.05f;
    [SerializeField] private float _dashCooldown = 2f;

    private bool _canDash = true;
    private float _nextDashTime = 0f;

    private float _dashLeft;
    private bool _isDashing = false;

    [Header("Settings - References")]
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private InCombat _combatState;

    private Vector2 _movementVector;
    private PlayerinputActions _playerInputActions;
    private Vector3 _velocity = Vector3.zero;


    public void Start()
    {
        _playerInputActions = new PlayerinputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Movement.performed += Movement_performed;
        _playerInputActions.Player.Movement.canceled += Movement_cancelled;

        _playerInputActions.Player.Dash.performed += Dash;
    }

    private void Awake()
    {
        if (_rb2d == null) { _rb2d = GetComponent<Rigidbody2D>(); }
        if (_combatState == null) { _combatState = GetComponent<InCombat>(); }
        if (_dashSystem == null) { GameObject.Find("DashSystem"); }
    }

    private void FixedUpdate()
    {
        if (!_isDashing)
        {
            if (_combatState.IsInCombat())
            {
                ProcessMovement(_combatSpeed);
            }
            else
            {
                ProcessMovement(_sprintSpeed);
            }
        }
    }

    private void ProcessMovement(float moveSpeed)
    {
        Vector3 targetVel = new Vector2(_movementVector.x * moveSpeed, _movementVector.y * moveSpeed);
        _rb2d.velocity = Vector3.SmoothDamp(_rb2d.velocity, targetVel, ref _velocity, _smoothSpeed);
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        _movementVector = obj.ReadValue<Vector2>();
    }

    private void Movement_cancelled(InputAction.CallbackContext obj)
    {
        _movementVector = Vector2.zero;
    }

    private void Dash(InputAction.CallbackContext obj)
    {
        if (_canDash)
        {
            _dashLeft = _dashTime;
            _isDashing = true;
            
            _canDash = false;
            _nextDashTime = _dashCooldown;

            _rb2d.velocity = Vector2.zero;

            _rb2d.AddForce(_dashSystem.transform.right * _dashForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (_nextDashTime > 0f && !_isDashing)
        {
            _nextDashTime -= Time.deltaTime;
        } else
        {
            _canDash = true;
        }

        if(_dashLeft > 0f)
        {
            _dashLeft -= Time.deltaTime;
        } else
        {
            _isDashing = false;
        }
    }
}
