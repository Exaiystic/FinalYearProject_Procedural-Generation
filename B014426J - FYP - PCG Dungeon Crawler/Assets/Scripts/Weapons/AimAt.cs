using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _target;

    private bool _weapon = false;
    private WeaponController _wepController;

    private void Start()
    {
        if (GetComponent<WeaponController>() != null)
        { 
            _weapon = true;
            _wepController = GetComponent<WeaponController>();
        }

        //Attempt to fallback onto the cursor if no target is given
        if (_target == null)
        {
            _target = GameObject.Find("Cursor").transform;
        }
    }

    private void Update()
    {
        if (_weapon)
        {
            if (_wepController.IsActive())
            {
                Aim();
            }
        } else
        {
            Aim();
        }
    }

    private void Aim()
    {
        if (_target != null)
        { transform.right = _target.position - transform.position; }
    }
}
