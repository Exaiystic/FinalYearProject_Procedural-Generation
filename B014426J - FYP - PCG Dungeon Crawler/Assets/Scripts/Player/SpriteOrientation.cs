using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteOrientation : MonoBehaviour
{
    [Header("Settings - General")]
    [SerializeField] private bool _flipWithScale = false;
    [SerializeField] private bool _flipOnX = true;
    [SerializeField] private bool _flipOnY = true;
    
    [Header("Settings - References")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Camera _cam;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private PlayerinputActions _playerInputActions;
    private Vector2 _playerScreenPoint;
    private Vector2 _mousePos;
    private bool _facingRight = true;

    private bool _attachedToWeapon = false;
    private WeaponController _wepController;

    private void Awake()
    {
        if (_playerInput == null) { _playerInput = GetComponent<PlayerInput>(); }
        if (_cam == null) { _cam = Camera.main; }

        if (!_flipWithScale)
        {
            if (_spriteRenderer == null) { _spriteRenderer = GetComponent<SpriteRenderer>(); }
        }
    }

    private void Start()
    {
        _playerInputActions = new PlayerinputActions();
        _playerInputActions.Player.Enable();

        if (GetComponent<WeaponController>())
        {
            _attachedToWeapon = true;
            _wepController = GetComponent<WeaponController>();
        }
    }

    void Update()
    {
        _mousePos = _playerInputActions.Player.Aiming.ReadValue<Vector2>();
        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(_mousePos);
                           
        if (_attachedToWeapon)
        {
            if (_wepController.IsActive())
            {
                //Flipping player sprite based on mousepos
                OrientateSprite();
            }
        } else
        {
            //Flipping player sprite based on mousepos
            OrientateSprite();
        }
    }

    private void OrientateSprite()
    {
        Vector3 charLocalScale = transform.localScale;
        //Vector3 wepLocalScale = hand.transform.localScale;

        //If mouse is on left of player, flip sprite
        _playerScreenPoint = _cam.WorldToScreenPoint(transform.position);
        if (_mousePos.x < _playerScreenPoint.x && _facingRight)
        {
            _facingRight = false;

            if (_flipWithScale)
            {
                charLocalScale.x = -1;    //Flips everything - including children sprites
            }
            else
            {
                if (_spriteRenderer != null)
                {
                    if (_flipOnX)
                    {
                        _spriteRenderer.flipX = true;    //Only flips the sprite
                        if (_flipOnY)
                        { _spriteRenderer.flipY = true; }
                    }
                    else
                    {
                        _spriteRenderer.flipY = true;
                    }
                }
            }
        }
        else if (_mousePos.x > _playerScreenPoint.x && !_facingRight)
        {
            _facingRight = true;

            if (_flipWithScale)
            {
                charLocalScale.x = 1;     //Flips everything - including children sprites
            } else
            {
                if (_spriteRenderer != null)
                {
                    if (_flipOnX)
                    {
                        _spriteRenderer.flipX = false;    //Only flips the sprite
                        if (_flipOnY)
                        { _spriteRenderer.flipY = false; }
                    }
                    else
                    {
                        _spriteRenderer.flipY = false;
                    }
                }
            }
        }

        transform.localScale = charLocalScale;
        //hand.transform.localScale = wepLocalScale;
    }
}
