using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Settings : MonoBehaviour
{
    public GameObject SelesaiMisiButton;
    public GameObject TerkumpulPanel;
    public GameObject SemangkaPanel;
    public GameObject Level2Panel;
    public GameObject nextLevel2Button;
    public AudioSource SoundSlider;

    void Start()
    {
        SelesaiMisiButton.SetActive(false);
    }
    
   public void selesaiButton()
    {
        Time.timeScale = 0;
        SoundSlider.Pause();
        TerkumpulPanel.SetActive(false);
        SemangkaPanel.SetActive(false);
        
        Level2Panel.SetActive(true);
        nextLevel2Button.SetActive(true);
    }

    public void NextLevel3Button()
    {
        nextLevel2Button.SetActive(false);
        PlayerPrefsManager.instance.SetLastScene("Main");
        SoundSlider.Play();
        Time.timeScale = 1;
    }
}
