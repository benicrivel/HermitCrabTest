using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private CharacterBase characterBase;

    private int maxHealth;
    private int currentHealth;
    private int attackDamage;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        SetupStats();
    }

    //Passes the stats from the ScriptableObject to the character and sets up the rest of the variables
    private void SetupStats()
    {
        maxHealth = characterBase.maxHealth;
        currentHealth = maxHealth;
        attackDamage = characterBase.attackDamage;
        animator = FindAnyObjectByType<Animator>();
    }

    //Method to be called when the character is damaged
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0) 
        {
            //If the character has died it'll be deleted from the scene
            Destroy(gameObject);
        }
    }
}
