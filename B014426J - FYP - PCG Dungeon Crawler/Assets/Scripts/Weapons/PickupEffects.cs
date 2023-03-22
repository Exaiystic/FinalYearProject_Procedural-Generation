using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEffects : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float pickupRange = 1f;
    [SerializeField] private GameObject effects;

    [Header("References")]
    [SerializeField] private Transform playerPos;
    [SerializeField] private WeaponController controller;

    private void Awake()
    {
        if (controller == null)
        { controller = GetComponent<WeaponController>(); }

        if (playerPos == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerPos = player.transform;
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);
        if (distanceToPlayer <= pickupRange && !controller.IsActive())
        {
            effects.SetActive(true);
        } else
        {
            effects.SetActive(false);
        }
    }
}
