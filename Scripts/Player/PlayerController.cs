using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")] 
    public float movementForce;
    public float jumpForce;
    [Space(5)] 
    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    public LayerMask whatIsGround;

    [Header("Seguimiento de la camara")] 
    public Camera cam;
    [Range(0f, 1f)] public float interpolation = 0.1f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    [Header("Animations")] 
    public Animator anim;
    public Transform head;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement();
        jump();
        camFollow();
    }

    private void movement()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDirection * (movementForce * Time.deltaTime), rb.velocity.y);
    }

    private void jump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) && isGround())
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
    }

    private bool isGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }

    private void camFollow()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, interpolation);
    }
}
