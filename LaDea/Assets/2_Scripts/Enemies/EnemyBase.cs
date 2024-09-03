using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float speed = 2f;

    protected Transform player;  // Referencia al jugador
    protected Rigidbody rb;  // Referencia al Rigidbody

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Encuentra al jugador
        rb = GetComponent<Rigidbody>();  // Obtén el componente Rigidbody
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Aquí podemos agregar efectos de muerte, partículas, etc.
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        // Implementar en las clases hijas.
    }
}
