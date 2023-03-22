using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Health health;

    private float maxHealth;

    private void Start()
    {
        //Bodged - as the health is only updated once damage is taken we need a seperate method to get the health at the start of play
        maxHealth = health.ReturnHealth();
        UpdateHealth(maxHealth);
    }

    private void Awake()
    {
        if (healthBar == null) { healthBar = GetComponent<Image>(); }
        if (health == null) { GetHealthReference(); }

        health.GetAccessingHealthDisplay(this);
    }

    private void GetHealthReference()
    {
        GameObject player = GameObject.Find("Character");
        health = player.GetComponent<Health>();
    }

    public void UpdateHealth(float newHealth)
    {
        healthBar.fillAmount = newHealth / maxHealth;
    }
}
