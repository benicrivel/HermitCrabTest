using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCombat : CharacterCombat
{
    [SerializeField]
    private CanShoot canShoot;
    [SerializeField]
    private Rigidbody2D rb;

    public PlayerCombat(ScoreManager _scoreManager, TimeManager _timemanager, MainMenu _mainmenu) : base(_scoreManager, _timemanager, _mainmenu)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupStats();
    }
}
