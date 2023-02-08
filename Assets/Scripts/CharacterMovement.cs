using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    public bool isJumping;
    public bool isGrounded;
    
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    
    private Vector3 _velocity = Vector3.zero;


    private void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;
    }
    
    private void FixedUpdate()
    {
        var horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MoveCharacter(horizontalMove);
    }
    
    private void MoveCharacter(float movement)
    {
        var velocity = rb.velocity;
    
        Vector3 targetVelocity = new Vector2(movement, velocity.y);
        rb.velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, .05f);
    
        if (!isJumping) return;
        
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
    }
}
