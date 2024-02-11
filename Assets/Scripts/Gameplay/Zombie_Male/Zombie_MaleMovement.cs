using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_MaleMovement : CharacterMovement
{
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    float groundCheckDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFlip();
        CheckGroundAhead();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (isFacingRight)
        {
            movement = new Vector2(0.2f, 0);
        }
        else
        {
            movement = new Vector2(-0.2f, 0);
        }
        MovementVelocity();
    }


    private void CheckGroundAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        // If there's no ground ahead, flip direction
        if (hit.collider == null)
        {
            Flip();
        }
    }
}
