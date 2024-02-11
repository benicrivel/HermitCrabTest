using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstTimeCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject highscoreGO;
    [SerializeField]
    private TMP_Text highscoreText;

    private void Awake()
    {
        if (PlayerPrefs.GetString("FirstTime") == "no")
        {
            highscoreGO.SetActive(true);
        }
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
