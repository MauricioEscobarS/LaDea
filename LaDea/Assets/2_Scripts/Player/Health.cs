using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealt = 3;
    public int currentHealt;
    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

