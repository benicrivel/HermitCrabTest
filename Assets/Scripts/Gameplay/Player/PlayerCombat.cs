using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    [SerializeField]
    private Transform projectileTransform;
    [SerializeField]
    private GameObject projectile;
    /*[SerializeField]
    private GameObject chargedProjectile;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootProjectile()
    {
        //if hold for X amount of time instantiate the stronger projectile, else normal projectile
        Instantiate(projectile, projectileTransform);
    }
}
