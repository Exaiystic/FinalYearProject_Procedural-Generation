using UnityEngine;

public class BasicShot : AttackBase
{
    [Header("Settings - General")]
    [SerializeField] private bool isHitScan;
    [SerializeField] private float spread;

    [Header("Settings - Projectiles")]
    [SerializeField] private int shotCount = 1;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject projectile;

    private void Start()
    {
        if (shotCount < 1)
            { shotCount = 1; }
    }

    public override void PrimaryAttack(float damage)
    {
        if (isHitScan)
            { HitScanShot(damage); } 
        else
            { ProjectileShot(damage); }
    }

    private void ProjectileShot(float damage)
    {
        for (int i = 0; i < shotCount; i++)
        {
            //Getting a projectile from the object pooler
            GameObject pooledObj = ObjectPooler.Instance.GetPooledObject(projectile.name);
            
            //Positioning the projectile
            pooledObj.transform.position = transform.position;

            //Rotating the projectile - will be offset by the spread angle
            pooledObj.transform.rotation = transform.rotation;
            pooledObj.transform.Rotate(transform.rotation.x, transform.rotation.y, GetSpreadAngle(transform.rotation.z));

            //Setting the stats of the projectile
            ProjectileBase projScript = pooledObj.GetComponent<ProjectileBase>();
            projScript.GetProjectileStats(damage, projectileSpeed);

            //Activating the projectile
            pooledObj.SetActive(true);
        }
    }

    private void HitScanShot(float damage)
    {
        Debug.Log("Hit scan not implemented");
    }

    private float GetSpreadAngle(float z)
    {
        z += Random.Range(-spread, spread);
        return z;
    }
}
