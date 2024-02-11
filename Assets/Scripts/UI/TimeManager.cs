using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private TMP_Text decimalTimeText;

    private float timeLeft;

    [Inject] MainMenu mainMenu;
    [SerializeField] GameObject deathMenu;

    public TimeManager(MainMenu _mainMenu)
    {
        mainMenu = _mainMenu;
    }

    private void Awake()
    {
        timeLeft = 15;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
        RefreshTimeText();
        if(timeLeft <= 0)
        {
            //open death menu
            mainMenu.OpenPauseMenu(deathMenu);
        }
    }

    private void RefreshTimeText()
    {
        //Separating the seconds and the decimal cases
        int seconds = Mathf.FloorToInt(timeLeft);
        float fraction = timeLeft - seconds;

        //Putting it all together with diferent sizes
        //string timeString = string.Format("<size=80>{0}</size><size=50>.{1:00}</size>", seconds, fraction * 100);

        timeText.text = seconds.ToString();
        decimalTimeText.text = ("."+ (fraction*100).ToString("F0"));
    }

    public void IncreaseTime(float extraTime)
    {
        timeLeft += extraTime;
    }

    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
    }
}
