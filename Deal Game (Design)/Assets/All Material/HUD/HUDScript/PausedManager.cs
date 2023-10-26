using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedManager : MonoBehaviour
{
    public GameObject joystick;
    public GameObject pausedButton;
    public GameObject pausedMenu;
    public GameObject settingsPanel;

    public void Paused()
    {
        Time.timeScale = 0;
        pausedButton.SetActive(false);
        joystick.SetActive(false);
        settingsPanel.SetActive(false);

        pausedMenu.SetActive(true);
    }

    public void Resume()
    {
        joystick.SetActive(true);
        pausedButton.SetActive(true);

        pausedMenu.SetActive(false);
        settingsPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        PlayerPrefsManager.instance.SetLastScene(SceneManager.GetActiveScene().name);
    }

    public void Settings()
    {
        Time.timeScale = 0;
        pausedButton.SetActive(false);
        joystick.SetActive(false);
        pausedMenu.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void BackButtonSettings()
    {
        Time.timeScale = 0;
        pausedButton.SetActive(false);
        joystick.SetActive(false);
        settingsPanel.SetActive(false);

        pausedMenu.SetActive(true); 
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        PlayerPrefsManager.instance.SetLastScene("Main");
    }
}
