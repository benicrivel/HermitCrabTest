using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private int lastHighScore;

    [SerializeField]
    private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        lastHighScore = PlayerPrefs.GetInt("Highscore");
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
        RefreshScoreText();
    }

    public void CheckForHighscore()
    {
        if(currentScore > lastHighScore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
        }
    }

    public void RefreshScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}
