using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    public GameObject settingsButton;
    public GameObject settingsPanel;

     public void Settings()
    {
        Time.timeScale = 0;
        settingsButton.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void BackButtonSettings()
    {
        settingsButton.SetActive(true);

        settingsPanel.SetActive(false);

        Time.timeScale = 1;
    }

}
