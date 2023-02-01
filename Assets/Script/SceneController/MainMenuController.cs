using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject LeaderboardPanel, SettingsPanel, SavedGamesPanel, SpecialMessage, BestiaryPanel;// всі панельки відкриваються при натисненні на кнопці

    private void Start()
    {
        LeaderboardPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        SavedGamesPanel.SetActive(false);
        SpecialMessage.SetActive(false);
        BestiaryPanel.SetActive(false);
    }

    public void OnClickLeaderboard()
    {

    }

    public void OnClickSettings()
    {

    }

    public void OnClickContinue()
    {

    }

    public void OnClickNewGame()
    {

    }

    public void OnClickBesteary()
    {

    }

    public void OnClickExit()
    {
        Application.Quit();
    }

}
