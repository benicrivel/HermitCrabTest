using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpingPower;
    private bool isFacingRight = true;

    //It's called when the player moves the joystick
    public void PlayerInput(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //Move the player based on the the joystick
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        //Checks which direction the player is facing and if it needs to be flipped
        if (!isFacingRight && movement.x > 0f)
        {
            Flip();
        }
        else if (isFacingRight && movement.x < 0f)
        {
            Flip();
        }


    }

    //Checks if the player is touching the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Jump using the Player Input System
    public void Jump(InputAction.CallbackContext context)
    {
        JumpButton();
    }

    //Base form of the jump so that it's able to be called by the UI button
    public void JumpButton()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    //Makes the character faces the oposite direction when moving
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
