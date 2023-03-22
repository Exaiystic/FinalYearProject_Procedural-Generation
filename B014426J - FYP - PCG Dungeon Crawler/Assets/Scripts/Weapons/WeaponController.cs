using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float damage;
    [SerializeField] private int manaCost;
    [SerializeField] private float attackSpeed;
    [SerializeField] private bool isFullAuto = false;
    [SerializeField] private bool isMelee = false;

    [Header("Effects")]
    [SerializeField] private CameraShake camShake;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeMagnitude = 0.15f;

    [Header("Settings - References")]
    [SerializeField] private AttackBase attackType;
    [SerializeField] private Mana mana;

    private PlayerinputActions playerInputActions;
    private float nextAttack = 0f;
    private bool attackHeld = false;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.PShooting.performed += PrimaryAttackPerformed;
        playerInputActions.Player.PShooting.canceled += PrimaryAttackCanceled;

        playerInputActions.Player.Melee.performed += MeleeAttackPerformed;
        playerInputActions.Player.Melee.canceled += MeleeAttackCanceled;

        CustomEventSystem.current.onNewDungeonEvent += ClearDroppedWeapon;

        if (isMelee)
        {
            SetIsActive(true);
        }
    }

    private void Awake()
    {
        if (mana == null)
            { mana = getManaReference(); }

        if (camShake == null)
            { camShake = Camera.main.GetComponent<CameraShake>(); }
    }

    private Mana getManaReference()
    {
        GameObject player = GameObject.Find("Character");
        return player.GetComponent<Mana>();
    }

    private void Update()
    {
        //Counting down until the next time the weapon can attack
        if (nextAttack > 0f) { nextAttack -= Time.deltaTime; }

        //Checking if the weapon is active
        if (isActive)
        {
            //Checking if the attack button is being pressed
            if (attackHeld)
            {
                //Checking to see if there is enough mana to perform the attack
                if (mana.GetMana() > manaCost)
                {
                    //Checking if the attack rate allows the weapon to fire
                    if (nextAttack <= 0f)
                    {
                        //Deducting the cost mana from the mana pool
                        mana.UseMana(manaCost);

                        //Attack functionality
                        attackType.PrimaryAttack(damage);
                        
                        //VFX
                        if (camShake != null)
                        {
                            StartCoroutine(camShake.ShakeCamera(shakeDuration, shakeMagnitude));
                        }

                        //Resetting the next attack to be the attack speed
                        nextAttack = attackSpeed;

                        //If the weapon is not automatic, do only one attack
                        if (!isFullAuto)
                        {
                            attackHeld = false;
                        }
                    }
                }
            }
        }
    }

    private void PrimaryAttackPerformed(InputAction.CallbackContext obj)
    {
        if (!isMelee)
            { attackHeld = true; }
    }

    private void PrimaryAttackCanceled(InputAction.CallbackContext obj)
    {
        if (!isMelee)
            { attackHeld = false; }
    }

    private void MeleeAttackPerformed(InputAction.CallbackContext obj)
    {
        if (isMelee)
        { attackHeld = true; }
    }

    private void MeleeAttackCanceled(InputAction.CallbackContext obj)
    {
        if (isMelee)
        { attackHeld = false; }
    }

    private void ClearDroppedWeapon()
    {
        if (!isActive)
        {
            Destroy(gameObject);
        }
    }

    public void SetIsActive(bool newState)
    {
        isActive = newState;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
