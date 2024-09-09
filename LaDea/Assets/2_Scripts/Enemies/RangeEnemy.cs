using UnityEngine;

public class RangeEnemy : EnemyBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float attackRange = 15f;
    public float fireRate = 1f;  // Tasa de disparo (proyectiles por segundo)
    private float nextFireTime = 0f;  // Control de tiempo para el siguiente disparo
    public float projectileSpeed = 10f;  // Velocidad del proyectil

    protected override void Update()
    {
        base.Update();

        if (player == null) return;  // Asegurarse de que el jugador existe

        // Hacer que el enemigo siempre mire al jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Verificar si el jugador está dentro del rango de ataque y si es tiempo de disparar
        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;  // Actualizar el tiempo para el próximo disparo
        }
    }

    private void Shoot()
    {
        if (firePoint == null)
        {
            Debug.LogError("No se ha asignado un firePoint para el enemigo.");
            return;
        }

        // Instanciar el proyectil en el firePoint y dispararlo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Direccionar el proyectil hacia el jugador
            Vector3 direction = (player.position - firePoint.position).normalized;
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("El proyectil no tiene un componente Rigidbody.");
        }
    }
}

