using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : CharacterMovement
{   
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float jumpingPower;
    private bool isGrounded = false;    

    //It's called when the player moves the joystick
    public void PlayerInput(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {   
        CheckGround();

        CheckFlip();
    }

    private void FixedUpdate()
    {                       
        MovementVelocity();
    }

    //Checks if the player is touching the ground
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isJumping", !isGrounded);
    }

    //Jump using the Player Input System
    public void Jump(InputAction.CallbackContext context)
    {
        JumpButton();
    }

    //Base form of the jump so that it's able to be called by the UI button
    public void JumpButton()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
        }
    }    
}
