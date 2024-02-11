using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    [SerializeField]
    private Transform projectileOrigin;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private string target;

    [SerializeField]
    private Animator animator;
    
    public void TriggerAnim()
    {
        animator.SetTrigger("Shoot");
    }

    public void ShootProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);

        Vector2 moveDirection = gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        newProjectile.GetComponent<Projectile>().SetMoveDirection(moveDirection);
    }
}    

