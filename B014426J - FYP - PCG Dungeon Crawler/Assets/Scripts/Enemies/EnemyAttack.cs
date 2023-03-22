using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage;
    [SerializeField] private int projectileSpeed;
    [SerializeField] private float attackRate;

    [Header("References")]
    [SerializeField] private GameObject attackInstigator;
    [SerializeField] private GameObject firePoint;

    private float nextTimeToFire;
    private bool canFire;

    private void Update()
    {
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / attackRate;
            canFire = true;
        }
    }

    public void Attack()
    {
        if (canFire && attackInstigator != null)
        {
            GameObject pooledObj = ObjectPooler.Instance.GetPooledObject(attackInstigator.name);
            pooledObj.transform.position = firePoint.transform.position;
            pooledObj.transform.rotation = firePoint.transform.rotation;

            ProjectileBase projScript = pooledObj.GetComponent<ProjectileBase>();
            projScript.GetProjectileStats(damage, projectileSpeed);

            pooledObj.SetActive(true);
            canFire = false;
            //Debug.Log("Pow");
        }
    }
}
