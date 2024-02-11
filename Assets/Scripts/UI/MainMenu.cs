using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        StartTime();
    }

    //Change/reload any scene by passing its name
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        StartTime();
    }

    //Close the game
    public void CloseGame()
    {
        Application.Quit();
    }

    public void TurnGOOn(GameObject go)
    {
        go.SetActive(true);
    }

    public void TurnGOOff(GameObject go)
    {
        go.SetActive(false);
        StartTime();
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void OpenPauseMenu(GameObject go)
    {
        StopTime();
        TurnGOOn(go);
    }

    public void ClosePauseMenu(GameObject go)
    {
        TurnGOOff(go);
        StartTime();
    }
}