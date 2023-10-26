using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backSettings : MonoBehaviour
{
    public void BackGame()
    {
        PlayerPrefsManager.instance.SetLastScene("Main");
    }

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
    
}
