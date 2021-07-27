using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [Header("Script para mantener el balance de las partes del cuerpo")]
    public float restingAngle = 0f;
    public float force = 750f;
    private Rigidbody2D rb;

    //When start call get the RigidBody
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Updates each frame
    private void FixedUpdate()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, restingAngle, force * Time.deltaTime));
    }
}
