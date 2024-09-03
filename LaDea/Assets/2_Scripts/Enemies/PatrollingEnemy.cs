using UnityEngine;

public class PatrollingEnemy : EnemyBase
{
    public Transform[] patrolPoints;  // Puntos de patrullaje
    private int currentPointIndex = 0;

    protected override void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;  // Cambia al siguiente punto
        }
    }
}
