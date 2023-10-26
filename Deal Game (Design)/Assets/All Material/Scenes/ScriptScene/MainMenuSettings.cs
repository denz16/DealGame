using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{
    public GameObject settingsButton;
    public GameObject settingsPanel;

    public GameObject Quest;
    public GameObject Quest1Button;
    public GameObject Quest1Panel;
    public GameObject Quest2Button;
    public GameObject Quest2Panel;
    public GameObject Quest3Button;
    public GameObject Quest3Panel;
    public GameObject Quest4Button;
    public GameObject Quest4Panel;
    public GameObject Mission1Panel;
    public GameObject MissionPanel;
    public GameObject Mission2Panel;
    public GameObject MissionPanel1;
    public GameObject Mission3Panel;
    public GameObject MissionPanel2;
    public GameObject Mission4Panel;
    public GameObject MissionPanel3;

    public GameObject DemoPanel;
    public GameObject PlayerDemoPanel;
    public GameObject Demo2Panel;
    public GameObject nextpanelButton;

    public GameObject Stage;
    public GameObject level1Button;
    public GameObject level1Panel;
    public GameObject level2Button;
    public GameObject level2Panel;
    public GameObject level3Button;
    public GameObject level3Panel;
    public GameObject level4Button;
    public GameObject level4Panel;
    
    public GameObject Maps;
    public GameObject HouseButton;
    public GameObject HousePanel;
    public GameObject StoreButton;
    public GameObject StorePanel;
    public GameObject BeruangButton;
    public GameObject BeruangPanel;
    public GameObject SavanaButton;
    public GameObject SavanaPanel;
    public GameObject MulaiPlayerButton;
    public GameObject MulaiPlayerPanel;

    public void StartButton()
    {
        if (PlayerPrefsManager.instance.GetLastScene() != "Main")
        {
            PlayerPrefsManager.instance.SetLastScene(PlayerPrefsManager.instance.GetLastScene());
        }
        else
        {
            PlayerPrefsManager.instance.SetLastScene("Home");
        }
        
    }

    public void QuestButton()
    {
        Quest.SetActive(true);
    }

    public void LevelButton()
    {
        Stage.SetActive(true);
    }

    public void MapsButton()
    {
        Maps.SetActive(true);
    }

    public void DemoButton()
    {
        DemoPanel.SetActive(true);
    }

    public void SettingsButton()
    {
        settingsButton.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void BackButtonSettings()
    {
        settingsButton.SetActive(true);

        settingsPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Quest1()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        Mission1Panel.SetActive(false);
        
        Quest1Panel.SetActive(true);
        MissionPanel.SetActive(true);
    }

    public void Mission1()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        MissionPanel.SetActive(false);

        Quest1Panel.SetActive(true);
        Mission1Panel.SetActive(true);
    }

    public void Quest2()
    {
        Quest1Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        Mission2Panel.SetActive(false);

        Quest2Panel.SetActive(true);
        MissionPanel1.SetActive(true);
    }

    public void Mission2()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        MissionPanel1.SetActive(false);

        Quest1Panel.SetActive(true);
        Mission2Panel.SetActive(true);
    }

    public void BackMission1()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        Mission2Panel.SetActive(false);

        Quest1Panel.SetActive(true);
        MissionPanel1.SetActive(true);
    }

    public void BackMission2()
    {
        Quest1Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        Mission2Panel.SetActive(false);

        Quest2Panel.SetActive(true);
        Mission2Panel.SetActive(true);
    }

    public void Quest3()
    {
        Quest2Panel.SetActive(false);
        Quest1Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);

        Quest3Panel.SetActive(true);
    }

    public void Mission3()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        MissionPanel2.SetActive(false);

        Quest1Panel.SetActive(true);
        Mission3Panel.SetActive(true);
    }

    public void BackMission3()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        MissionPanel2.SetActive(false);

        Quest1Panel.SetActive(true);
        Mission3Panel.SetActive(true);
    }

    public void Quest4()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest1Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);

        Quest4Panel.SetActive(true);
    }

    public void Mission4()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        MissionPanel3.SetActive(false);

        Quest1Panel.SetActive(true);
        Mission4Panel.SetActive(true);
    }

    public void BackMission4()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest2Button.SetActive(false);
        Quest3Button.SetActive(false);
        Quest4Button.SetActive(false);
        Quest1Button.SetActive(false);
        Mission4Panel.SetActive(false);

        Quest1Panel.SetActive(true);
        MissionPanel3.SetActive(true);
    }

    public void back11Button()
    {
        Quest2Panel.SetActive(false);
        Quest3Panel.SetActive(false);
        Quest4Panel.SetActive(false);
        Quest1Panel.SetActive(false);

        Quest2Button.SetActive(true);
        Quest3Button.SetActive(true);
        Quest4Button.SetActive(true);
        Quest1Button.SetActive(true);
    }

    public void BackGame()
    {
        Quest.SetActive(false);
    }

    public void Level()
    {
        Stage.SetActive(true);
        Quest.SetActive(false);
    }

    public void Demo()
    {
        DemoPanel.SetActive(true);
        Quest.SetActive(false);
    }

    public void GetMission()
    {
        PlayerPrefsManager.instance.SetLastScene("Home");
    }

    public void Level1()
    {
        level2Panel.SetActive(false);
        level3Panel.SetActive(false);
        level4Panel.SetActive(false);

        level2Button.SetActive(true);
        level3Button.SetActive(true);
        level4Button.SetActive(true);
        level1Button.SetActive(true);
        level1Panel.SetActive(true);
    }

    public void Level2()
    {
        level1Panel.SetActive(false);
        level3Panel.SetActive(false);
        level4Panel.SetActive(false);

        level2Button.SetActive(true);
        level3Button.SetActive(true);
        level4Button.SetActive(true);
        level1Button.SetActive(true);
        level2Button.SetActive(true);
        level2Panel.SetActive(true);
    }

    public void Level3()
    {
        level2Panel.SetActive(false);
        level1Panel.SetActive(false);
        level4Panel.SetActive(false);

        level2Button.SetActive(true);
        level3Button.SetActive(true);
        level4Button.SetActive(true);
        level1Button.SetActive(true);
        level3Button.SetActive(true);
        level3Panel.SetActive(true);
    }

    public void Level4()
    {
        level2Panel.SetActive(false);
        level3Panel.SetActive(false);
        level1Panel.SetActive(false);

        level2Button.SetActive(true);
        level3Button.SetActive(true);
        level4Button.SetActive(true);
        level1Button.SetActive(true);
        level4Button.SetActive(true);
        level4Panel.SetActive(true);
    }

    public void BackStageButton()
    {
        Stage.SetActive(false);
    }

    public void NextPanelButton()
    {
        Demo2Panel.SetActive(true);
        
        PlayerDemoPanel.SetActive(false);
        nextpanelButton.SetActive(false);
    }

    public void BackPlayButton()
    {
        DemoPanel.SetActive(false);
    }

     public void House()
    {
        
        StoreButton.SetActive(false);
        StorePanel.SetActive(false);
        BeruangButton.SetActive(false);
        BeruangPanel.SetActive(false);
        SavanaButton.SetActive(false);
        SavanaPanel.SetActive(false);
        MulaiPlayerButton.SetActive(false);
        MulaiPlayerPanel.SetActive(false);
        HouseButton.SetActive(false);

        HousePanel.SetActive(true);
    }

     public void Store()
    {
        
        StoreButton.SetActive(false);
        BeruangButton.SetActive(false);
        BeruangPanel.SetActive(false);
        SavanaButton.SetActive(false);
        SavanaPanel.SetActive(false);
        MulaiPlayerButton.SetActive(false);
        MulaiPlayerPanel.SetActive(false);
        HouseButton.SetActive(false);
        HousePanel.SetActive(false);

        StorePanel.SetActive(true);
    }

    public void Beruang()
    {
        
        StoreButton.SetActive(false);
        StorePanel.SetActive(false);
        BeruangButton.SetActive(false);
        SavanaButton.SetActive(false);
        SavanaPanel.SetActive(false);
        MulaiPlayerButton.SetActive(false);
        MulaiPlayerPanel.SetActive(false);
        HouseButton.SetActive(false);
        HousePanel.SetActive(false);

        BeruangPanel.SetActive(true);
    }

    public void Savana()
    {
        
        StoreButton.SetActive(false);
        StorePanel.SetActive(false);
        BeruangButton.SetActive(false);
        BeruangPanel.SetActive(false);
        SavanaButton.SetActive(false);
        MulaiPlayerButton.SetActive(false);
        MulaiPlayerPanel.SetActive(false);
        HouseButton.SetActive(false);
        HousePanel.SetActive(false);

        SavanaPanel.SetActive(true);
    }

    public void MulaiPlayer()
    {
        
        StoreButton.SetActive(false);
        StorePanel.SetActive(false);
        BeruangButton.SetActive(false);
        BeruangPanel.SetActive(false);
        SavanaButton.SetActive(false);
        SavanaPanel.SetActive(false);
        MulaiPlayerButton.SetActive(false);
        HouseButton.SetActive(false);
        HousePanel.SetActive(false);

        MulaiPlayerPanel.SetActive(true);
    }

    public void Back()
    {
        
        StorePanel.SetActive(false);
        BeruangPanel.SetActive(false);
        SavanaPanel.SetActive(false);
        MulaiPlayerPanel.SetActive(false);
        HousePanel.SetActive(false);

        StoreButton.SetActive(true);
        BeruangButton.SetActive(true);
        SavanaButton.SetActive(true);
        MulaiPlayerButton.SetActive(true);
        HouseButton.SetActive(true);
    }

    public void BackButton()
    {
        Maps.SetActive(false);
    }
        
}
