using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    public float triggerYPosition;
    public float explosionRadius = 2f;
    public float explosionDamage = 50f;
    private GameObject player;
    private Transform playerTransform;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        triggerYPosition = Camera.main.orthographicSize / 2;
    }

    void Update()
    {
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= explosionRadius)
        {
            // Explode();
        }
    }

    // void Explode()
    // {
    //     // Daño al jugador
    //     PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();  // Requiere un componente que gestione la salud del jugador
    //     if (playerHealth != null)
    //     {
    //         playerHealth.TakeDamage(explosionDamage);
    //     }

    //     // añadir efectos de explosión, partículas, sonido, etc.
    //     Debug.Log("¡El enemigo explota!");
    //     Destroy(gameObject);
    // }
}