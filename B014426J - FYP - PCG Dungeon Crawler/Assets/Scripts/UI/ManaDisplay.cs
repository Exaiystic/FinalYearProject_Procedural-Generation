using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image manaBar;
    [SerializeField] private Mana mana;

    private float maxMana;

    private void Start()
    {
        maxMana = mana.GetMaxMana();
    }

    private void Awake()
    {
        if (mana == null)
            { mana = GetManaReference(); }

        if (manaBar == null)
            { manaBar.GetComponent<Image>(); }
    }

    private Mana GetManaReference()
    {
        GameObject player = GameObject.Find("Character");
        return player.GetComponent<Mana>();
    }

    private void Update()
    {
        float currentMana = mana.GetMana();
        UpdateManaBar(currentMana);

    }

    private void UpdateManaBar(float newManaAmount)
    {
        manaBar.fillAmount = newManaAmount / maxMana;
    }
}
