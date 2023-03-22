using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EchoFX : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float startTimeBetweenSpawns = 0.05f;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private GameObject echoAsset;
    [SerializeField] private ParticleSystem psAsset;

    private float timeBetweenSpawns = 0f;
    private float durationTime = 0f;
    private bool isSpawning = false;

    private PlayerinputActions playerInputActions;

    private void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Dash.performed += StartFX;
    }

    private void StartFX(InputAction.CallbackContext obj)
    {
        isSpawning = true;
        durationTime = duration;

        if (psAsset != null)
        {
            Instantiate(psAsset, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (timeBetweenSpawns <= 0 && isSpawning)
        {
            if (echoAsset != null)
            {
                //Should be moved to object pooler
                GameObject instance = Instantiate(echoAsset, transform.position, Quaternion.identity);
                Destroy(instance, 1f);
            }
            timeBetweenSpawns = startTimeBetweenSpawns;
        } else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

        if (durationTime > 0f)
        {
            durationTime -= Time.deltaTime;
        } else
        {
            isSpawning = false;
        }
    }
}
