using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupAndDrop : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float pickupRange;
    [SerializeField] private Hotbar hotbarSlot;

    private PlayerinputActions playerInputActions;

    private GameObject weapon;
    private WeaponController weaponController;
    private bool isSlotOccupied;

    private void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Drop.performed += DropWeapon;
        playerInputActions.Player.Interact.performed += PickUpWeapon;

        CustomEventSystem.current.onPlayerDeathEvent += EmptyInventory;

        GetWeaponComponent();
    }

    private void GetWeaponComponent()
    {
        //Getting a reference to any weapon within the slot
        weaponController = GetComponentInChildren<WeaponController>();

        if (weaponController == null)
            { isSlotOccupied = false; }
        else
        {
            isSlotOccupied = true;
            weapon = gameObject.transform.GetChild(0).gameObject;
        }
    }

    private void PickUpWeapon(InputAction.CallbackContext obj)
    {
        if (gameObject.activeSelf)
        {
            if (!isSlotOccupied)
            {
                GameObject[] allWeapons = GameObject.FindGameObjectsWithTag("Weapon");
                List<GameObject> weaponsInRange = new List<GameObject>();
                GameObject closestWeapon = null;

                //Getting all weapons in range
                for (int i = 0; i < allWeapons.Length; i++)
                {
                    float distance = Vector2.Distance(allWeapons[i].transform.position, transform.position);
                    if (distance <= pickupRange)
                    {
                        weaponsInRange.Add(allWeapons[i]);
                    }
                }

                //Getting the closest weapons of the weapons in range
                float minDist = Mathf.Infinity;
                foreach (GameObject x in weaponsInRange)
                {
                    float dist = Vector2.Distance(x.transform.position, transform.position);
                    if (dist < minDist)
                    {
                        closestWeapon = x;
                        minDist = dist;
                    }
                }

                //Assigning the closest weapon to slot
                if (closestWeapon != null)
                {
                    closestWeapon.transform.parent = transform;
                    closestWeapon.transform.localPosition = Vector3.zero;
                    GetWeaponComponent();
                    weaponController.SetIsActive(true);

                    if (hotbarSlot != null)
                    {
                        SpriteRenderer weaponSprite = closestWeapon.GetComponent<SpriteRenderer>();
                        if (weaponSprite == null)
                            { weaponSprite = closestWeapon.GetComponentInChildren<SpriteRenderer>(); }

                        hotbarSlot.WeaponPickedUp(weaponSprite.sprite);
                    }
                }
            }
        }
    }

    private void DropWeapon(InputAction.CallbackContext obj)
    {
        EmptyInventory();
        
        /*
        if (gameObject.activeSelf)
        {
            if (isSlotOccupied)
            {
                weaponController.SetIsActive(false);
                weapon.transform.parent = null;
                isSlotOccupied = false;

                weapon = null;
                weaponController = null;
            }
        }
        */
    }

    private void EmptyInventory()
    {
        if (gameObject.activeSelf)
        {
            if (isSlotOccupied)
            {
                weaponController.SetIsActive(false);
                weapon.transform.parent = null;
                isSlotOccupied = false;

                weapon = null;
                weaponController = null;

                if (hotbarSlot != null)
                    { hotbarSlot.WeaponDropped(); }
            }
        }
    }
}
