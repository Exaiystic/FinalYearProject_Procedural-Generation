using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [Header("Settings - General")]
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float regenerationRate;
    [SerializeField] private float regenerationDelay;

    private float currentMana = 0f;
    private float timeBeforeRegen = 0f;

    private void Update()
    {
        //Counting down the regen timer
        if (timeBeforeRegen > 0f && currentMana != maxMana) 
            { timeBeforeRegen -= Time.deltaTime; }
        else
            { regenerateMana(); }
    }

    private void regenerateMana()
    {
        if (currentMana < maxMana)
            { currentMana += regenerationRate * Time.deltaTime; }
    }

    public void UseMana(float manaAmount)
    {
        if (manaAmount != 0f)
        {
            currentMana -= manaAmount;
            timeBeforeRegen = regenerationDelay;
        }
    }

    public float GetMana()
    {
        return currentMana;
    }

    public float GetMaxMana()
    {
        return maxMana;
    }
}
