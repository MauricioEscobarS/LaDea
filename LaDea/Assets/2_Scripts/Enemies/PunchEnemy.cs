using UnityEngine;

public class PunchEnemy : MonoBehaviour
{
    public float punchRange = 1.5f;
    public float punchDamage = 25f;
    public float punchCooldown = 2f;

    private MeleEnemy meleEnemy;
    private float nextPunchTime = 0f;

    void Start()
    {
        meleEnemy = GetComponent<MeleEnemy>();
    }

    void Update()
    {
        if (meleEnemy != null && meleEnemy.GetPlayerTransform() != null)
        {
            // Comprobar si está en rango de golpe y si puede golpear
            if (Vector3.Distance(transform.position, meleEnemy.GetPlayerTransform().position) <= punchRange && Time.time >= nextPunchTime)
            {
                Punch();
            }
        }
    }

    void Punch()
    {
        // Daño al jugador
        // PlayerHealth playerHealth = meleEnemy.GetPlayerTransform().GetComponent<PlayerHealth>();
        // if (playerHealth != null)
        // {
        //     playerHealth.TakeDamage(punchDamage);
        // }

        // Debug.Log("El enemigo golpea al jugador.");
        // nextPunchTime = Time.time + punchCooldown;  // Establecer el tiempo para el siguiente golpe
    }
}
