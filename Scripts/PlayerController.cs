using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D rb;

    [Header("Layers")] 
    [SerializeField] private LayerMask isGroundLayer;
    
    [Header("Variables de movimiento")]
    [SerializeField] private float movementAcceleration;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float linearDrag;
    private float horizontalDirection;
    private bool changeDirection =>
        (rb.velocity.x > 0f && horizontalDirection < 0f) || (rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Variables de salto")] 
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float airLinearDrag = 2.5f;
    [SerializeField] private float fallMultiplier = 8f;
    [SerializeField] private float lowJumpFallMultiplier = 5f;
    [SerializeField] private float jumpDelay = 0.15f;
    [SerializeField] private int extraJumps = 1;
    private float jumpTimer;
    private int extraJumpValue;
    private bool canJump => Input.GetButtonDown("Jump") && (onGround && extraJumpValue > 0);

    [Header("Variables de collision ground")]
    [SerializeField] private float groundRayCastLength;
    [SerializeField] private Vector3 groundRaycastOffset;
    private bool onGround;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = getInput().x;
    }
    private void FixedUpdate()
    {
        checkCollisions();
        moveCharacter();
        applyGroundLinearDragToCharacter();
        if (canJump) jump();
        if (onGround)
        {
            extraJumpValue = extraJumps;
            applyGroundLinearDragToCharacter();
        }
        else
        {
            applyAirLinearDragToCharacter();
            fallingMultiplier();
        }
    }
    private static Vector2 getInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void moveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAcceleration);
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
    }
    private void applyGroundLinearDragToCharacter()
    {
        //primer ternary operator :0
        rb.drag = Mathf.Abs(horizontalDirection) < 0.4f || (changeDirection) ? linearDrag : 0f;
    }
    private void applyAirLinearDragToCharacter()
    {
        rb.drag = airLinearDrag;
    }
    private void jump()
    {
        if (!onGround) extraJumpValue--;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }

    private void fallingMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }else if (rb.velocity.y > 0 && !Input.GetButton(("Jump")))
        {
            rb.gravityScale = lowJumpFallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void checkCollisions()
    {
        onGround = Physics2D.Raycast(transform.position + groundRaycastOffset, Vector2.down, groundRayCastLength, isGroundLayer) ||
                    Physics2D.Raycast(transform.position - groundRaycastOffset, Vector2.down, groundRayCastLength, isGroundLayer);    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRayCastLength);
    }
}