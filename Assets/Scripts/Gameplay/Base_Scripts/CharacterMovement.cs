using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 3f;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected bool isFacingRight = true;

    // Update is called once per frame
    private void Update()
    {
        CheckFlip();
    }

    private void FixedUpdate()
    {
        //Move the character based on the the joystick
        MovementVelocity();
    }

    protected void MovementVelocity()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        animator.SetFloat("xMovement", Math.Abs(rb.velocity.x));
        animator.SetFloat("yMovement", rb.velocity.y);
    }

    protected void CheckFlip()
    {
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

    //Makes the character faces the oposite direction when moving
    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
