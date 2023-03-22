using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Settings - References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private DamageOnTriggerEnter damageScript;

    private float damage;
    private float speed;
    private PooledObject po;

    private void Awake()
    {
        if (rb == null)
            { rb = GetComponent<Rigidbody2D>(); }
        if (damageScript == null)
            { damageScript = GetComponent<DamageOnTriggerEnter>(); }
    }

    void OnEnable()
    {
        rb.velocity = transform.right * speed;
    }

    public void GetProjectileStats(float dmg, float spd)
    {
        damage = dmg;
        speed = spd;

        damageScript.SetDamage(damage);
    }
}
