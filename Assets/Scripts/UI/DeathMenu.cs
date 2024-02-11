using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    [Inject] ScoreManager scoreManager;

    [SerializeField]
    private TMP_Text scoreText;

    public DeathMenu(ScoreManager _scoreManager)
    {
        scoreManager = _scoreManager;
    }

    private void Awake()
    {
        SetScoreText();
        CheckForHighscore();
        CheckFirstTime();
    }

    private void SetScoreText()
    {
        scoreText.text = ("You've got " + scoreManager.GetScore().ToString()+ " points though!");
    }

    private void CheckFirstTime()
    {
        if(PlayerPrefs.GetString("FirstTime") != "no")
        {
            PlayerPrefs.SetString("FirstTime", "no");
        }
    }

    private void CheckForHighscore()
    {
        scoreManager.CheckForHighscore();
    }
}
