using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public Rigidbody rb;


    void Start()
    {
        Debug.Log("Incio del Juego");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Juego en progreso");
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x,0,z) * speed;
    }
}
