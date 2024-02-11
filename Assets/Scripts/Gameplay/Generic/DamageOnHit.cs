using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private string target;
    [SerializeField]
    private bool selfDestruct;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            collision.gameObject.GetComponent<CharacterCombat>().TakeDamage(damage);
            
            //selfdestruct after collision
            if (selfDestruct)
            {
                SelfDestruct();
            }
        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
