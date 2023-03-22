using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTriggerEnter : MonoBehaviour
{
    [Header("Settings - General")]
    [SerializeField] private bool isInObjectPooler;

    private PooledObject po;

    private float damage;

    private void OnEnable()
    {
        if (po == null)
            { po = GetComponent<PooledObject>(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeSelf)
        {
            GameObject hitActor = collision.gameObject;
            if (hitActor.GetComponent<Health>() != null)
            {
                Health hitActorHealth = hitActor.GetComponent<Health>();
                hitActorHealth.TakeDamage(damage);
            }
        }

        if (isInObjectPooler)
            { po.RecycleSelf(); }
    }

    public void SetDamage(float pDamage)
    {
        damage = pDamage;
    }
}
