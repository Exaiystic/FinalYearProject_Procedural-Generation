using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _followCursor = true;
    [SerializeField] private Transform _target;

    private PlayerinputActions _playerInputActions;
    private Vector2 _pos;

    private void Start()
    {
        _playerInputActions = new PlayerinputActions();
        _playerInputActions.Player.Enable();
    }

    private void LateUpdate()
    {
        if (_followCursor)
        {
            Vector3 mousePosition = _playerInputActions.Player.Aiming.ReadValue<Vector2>();
            _pos = Camera.main.ScreenToWorldPoint(mousePosition);
        }
        else if (_target != null)
        {
            _pos = _target.position;
        }

        transform.position = _pos;
    }
}
