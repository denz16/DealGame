using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerPrefsManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    
    public float GetCameraZoom()
    {
        return PlayerPrefs.GetFloat("CameraZoom", 40f);
    }

    public float SetCameraZoom(float cameraZoom)
    {
        PlayerPrefs.SetFloat("CameraZoom", cameraZoom);
        return GetCameraZoom();
    }

    public float GetSensitivity()
    {
        return PlayerPrefs.GetFloat("Sensitivity", 60f);
    }

    public float SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        return GetSensitivity();
    }

    public string GetLastScene()
    {
        return PlayerPrefs.GetString("LastScene", "Home");
    }

    public void SetLastScene(string nameScene)
    {
        PlayerPrefs.SetString("LastScene", nameScene);
        SceneManager.LoadScene("Loading");
    }


    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
