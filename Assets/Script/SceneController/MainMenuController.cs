using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject LeaderboardPanel, SettingsPanel, SavedGamesPanel, SpecialMessage, BestiaryPanel;// всі панельки відкриваються при натисненні на кнопці
	
	public TextMeshProUGUI SpecialMessageHeader;
	
	
	public GameObject[] mainMenuItems;
	bool didSavesExist = false, save1 = false, save2 = false, save3 = false;

    public GameObject SaveOrLoadButton1, SaveOrLoadButton2, SaveOrLoadButton3;
    public TextMeshProUGUI SaveButonText1, SaveButonText2, SaveButonText3;
    public Image SavePanelImage1, SavePanelImage2, SavePanelImage3; 

    public Sprite SaveExist, SaveDoestExist;

    private void Start()
    {
        OnClickExitFomPanel();
        if(save1 == true || save2 == true || save3 == true)
        {
            didSavesExist = true;
        }

    }

    public void OnClickLeaderboard()
    {
		LeaderboardPanel.SetActive(true);
		for(int i = 0; i < mainMenuItems.Length; i++)
		{
            mainMenuItems[i].SetActive(false);
		}
    }

    public void OnClickSettings()
    {
		SettingsPanel.SetActive(true);
		for(int i = 0; i < mainMenuItems.Length; i++)
		{
            mainMenuItems[i].SetActive(false);
		}
    }

    public void OnClickContinue()
    {
		SavedGamesPanel.SetActive(true);

        if(save1 == true)
        {
            SaveOrLoadButton1.SetActive(true);
            SavePanelImage1.sprite = SaveExist;
            SaveButonText1.text = "Load save";
        }
        if (save2 == true)
        {
            SaveOrLoadButton2.SetActive(true);
            SavePanelImage2.sprite = SaveExist;
            SaveButonText2.text = "Load save";
        }
        if (save3 == true)
        {
            SaveOrLoadButton3.SetActive(true);
            SavePanelImage3.sprite = SaveExist;
            SaveButonText3.text = "Load save";
        }

        for (int i = 0; i < mainMenuItems.Length; i++)
		{
            mainMenuItems[i].SetActive(false);
		}

    }

    public void OnClickNewGame()
    {
        //SavedGamesPanel.SetActive(true);
        //for(int i = 0; i < mainMenuItems.Length; i++)
        //{
        //          mainMenuItems[i].SetActive(false);
        //}
        //      if (save1 == true)
        //      {
        //          SaveOrLoadButton1.SetActive(true);
        //          SavePanelImage1.sprite = SaveExist;
        //          SaveButonText1.text = "Load save";
        //      }
        //      if (save2 == true)
        //      {
        //          SaveOrLoadButton2.SetActive(true);
        //          SavePanelImage2.sprite = SaveExist;
        //          SaveButonText2.text = "Load save";
        //      }
        //      if (save3 == true)
        //      {
        //          SaveOrLoadButton3.SetActive(true);
        //          SavePanelImage3.sprite = SaveExist;
        //          SaveButonText3.text = "Load save";
        //      }

        //Треба буде зробити систему збережень, а поки, просто гравець переходить на мапу місій

        SceneManager.LoadScene("TravelMap");

    }

    public void OnClickBesteary()
    {
		BestiaryPanel.SetActive(true);
		for(int i = 0; i < mainMenuItems.Length; i++)
		{
            mainMenuItems[i].SetActive(false);
		}
    }
	
	public void OnClickExitFomPanel()
	{
		LeaderboardPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        SavedGamesPanel.SetActive(false);
        SpecialMessage.SetActive(false);
        BestiaryPanel.SetActive(false);
		
		for(int i = 0; i < mainMenuItems.Length; i++)
		{
            mainMenuItems[i].SetActive(true);
		}
	}

    public void OnClickExit()
    {
        //SpecialMessage.SetActive(true);

        Application.Quit();
    }

}
