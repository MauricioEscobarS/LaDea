using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float speed = 2f;

    protected Transform player;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        rb = GetComponent<Rigidbody>();
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
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
    }
}
