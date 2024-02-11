using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private CharacterBase characterBase;

    protected int maxHealth;
    protected int currentHealth;
    protected int attackDamage;

    [SerializeField]
    protected Animator animator;

    [Inject] ScoreManager scoreManager;
    [Inject] TimeManager timeManager;
    [Inject] MainMenu mainMenu;
    [SerializeField] GameObject deathMenu;

    public CharacterCombat (ScoreManager _scoreManager, TimeManager _timemanager, MainMenu _mainmenu)
    {
        scoreManager = _scoreManager;
        timeManager = _timemanager;
        mainMenu = _mainmenu;
    }

    //inject points manager
    //inject DeathMenu

    void Start()
    {
        SetupStats();
    }

    //Passes the stats from the ScriptableObject to the character and sets up the rest of the variables
    protected void SetupStats()
    {
        maxHealth = characterBase.GetMaxHealth();
        currentHealth = maxHealth;
        attackDamage = characterBase.GetAttackDamage();
        animator = FindAnyObjectByType<Animator>();
    }

    //Method to be called when the character is damaged
    public void TakeDamage(int damage)
    {
        //ApplyKnockback(collisionDirection);
        currentHealth -= damage;
        Debug.Log("currenthealth: " + currentHealth);
        if(currentHealth <= 0) 
        {
            if(tag == "Enemy")
            {
                scoreManager.IncreaseScore(100);
                timeManager.IncreaseTime(5);
            }
            else if(tag == "Player")
            {
                mainMenu.OpenPauseMenu(deathMenu);
            }
            //if enemy give points
            //If the character has died it'll be deleted from the scene
            Destroy(gameObject);
        }
    }
}
