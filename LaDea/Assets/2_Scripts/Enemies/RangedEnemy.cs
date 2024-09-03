using UnityEngine;

public class RangedEnemy : EnemyBase
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public float attackRange = 15f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    protected override void Update()
    {
        base.Update();

        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f;  // Ajusta la velocidad del proyectil
    }
}
