using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour
{
    [Header("Settings - Weapons")]
    [SerializeField] private GameObject[] weapons = new GameObject[3];
    [SerializeField] [Range(0, 2)] private int startingWeaponIndex = 0;
    
    [Header("Settings - References")]
    [SerializeField] private PlayerInput playerInput;

    private PlayerinputActions playerInputActions;

    private void Awake()
    {
        if (playerInput == null) { playerInput = GetComponent<PlayerInput>(); }
    }

    private void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.WeaponSlot1.performed += SwitchToFirstSlot;
        playerInputActions.Player.WeaponSlot2.performed += SwitchToSecondSlot;
        playerInputActions.Player.WeaponSlot3.performed += SwitchToThirdSlot;

        SwitchToWeaponSlot(startingWeaponIndex);
    }

    //Bodged - should be able to call SwitchToWeaponSlot straight from the inputactions but a NRE on 'performed' error occurs
    private void SwitchToFirstSlot(InputAction.CallbackContext obj)
    {
        SwitchToWeaponSlot(0);
    }

    private void SwitchToSecondSlot(InputAction.CallbackContext obj)
    {
        SwitchToWeaponSlot(1);
    }

    private void SwitchToThirdSlot(InputAction.CallbackContext obj)
    {
        SwitchToWeaponSlot(2);
    }

    private void SwitchToWeaponSlot(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            WeaponController wController = weapons[i].GetComponentInChildren<WeaponController>();
            
            if (i == index)
            {
                weapons[i].SetActive(true);

                if (wController != null)
                {
                    wController.SetIsActive(true);
                }
            } else
            {
                weapons[i].SetActive(false);

                if (wController != null)
                {
                    wController.SetIsActive(false);
                }
            }
        }
    }
}
