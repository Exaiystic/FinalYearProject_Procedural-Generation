using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTowardsPlayer : MonoBehaviour
{
    [Header("Settings - References")]
    [SerializeField] private EnemyAI enemyAI;

    private GameObject target;

    private void Awake()
    {
        if (enemyAI == null)
        { enemyAI = GetComponentInParent<EnemyAI>(); }

        target = enemyAI.ReturnTarget();
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
