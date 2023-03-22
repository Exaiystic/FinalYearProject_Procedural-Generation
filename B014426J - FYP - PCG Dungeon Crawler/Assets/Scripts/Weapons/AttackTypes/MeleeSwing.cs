using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSwing : AttackBase
{
    [Header("Settings - References")]
    [SerializeField] private GameObject weaponGameObject;
    [SerializeField] private BoxCollider2D weaponCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private DamageOnTriggerEnter damageScript;
    [SerializeField] private TrailRenderer trailRenderer;

    private void Awake()
    {
        if (weaponGameObject == null)
            { weaponGameObject = gameObject.transform.GetChild(0).gameObject; }
        if (weaponCollider == null)
            { weaponCollider = weaponGameObject.GetComponent<BoxCollider2D>(); }
        if (animator == null)
            { animator = GetComponent<Animator>(); }
        if (damageScript == null)
            { damageScript = GetComponent<DamageOnTriggerEnter>(); }
    }

    private void Start()
    {
        weaponGameObject.SetActive(false);
    }

    public override void PrimaryAttack(float damage)
    {
        damageScript.SetDamage(damage);
        weaponGameObject.SetActive(true);
        if (animator != null)
        { animator.SetTrigger("Attacked"); }
    }

    public void SwingEnded()
    {
        if (trailRenderer != null)
        {
            trailRenderer.Clear();
        }
        weaponGameObject.SetActive(false);
    }
}
