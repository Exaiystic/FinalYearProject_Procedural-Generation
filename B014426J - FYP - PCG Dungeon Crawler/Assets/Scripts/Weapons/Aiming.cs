using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    [Header("Settings - References")]
    [SerializeField] private WeaponController controller;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Camera cam;

    private PlayerinputActions playerInputActions;
    private Vector2 mousePos;

    private void Awake()
    {
        if (controller == null) { controller = GetComponent<WeaponController>(); }
        if (playerInput == null) { playerInput = GetComponent<PlayerInput>(); }
        if (cam == null) { cam = Camera.main; }
    }

    public void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();
    }

    void Update()
    {
        if (controller != null)
        {
            if (controller.IsActive())
            {
                Aim();
            }
        } else
        {
            Aim();
        }
    }

    private void Aim()
    {
        mousePos = playerInputActions.Player.Aiming.ReadValue<Vector2>();
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        Vector3 targetDir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
