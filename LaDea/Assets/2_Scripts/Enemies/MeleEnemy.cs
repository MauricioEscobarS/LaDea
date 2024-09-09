using UnityEngine;

public class MeleEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float chaseSpeed = 5f;
    public float triggerYPosition;
    public float lookSpeed = 5f;

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
        if (transform.position.y > triggerYPosition)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            ChasePlayer();
        }
    }

    protected void ChasePlayer()
    {
        if (playerTransform != null)
        {
            // Mirar hacia el jugador
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);

            // Perseguir al jugador
            transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
        }
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
}
