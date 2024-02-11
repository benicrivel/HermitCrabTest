using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float timeAlive = 4f;

    private Vector2 moveDirection;

    [SerializeField]
    private DamageOnHit dOH;

    // Start is called before the first frame update
    void Awake()
    {
        SelfDestroyDelay();
    }

    private void Start()
    {
        //If it's going left, flip the image
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        // go forward
        MoveBullet();
    }

    private void Flip()
    {
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void MoveBullet()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void SelfDestroyDelay()
    {
        Destroy(gameObject, timeAlive);
    }
}
