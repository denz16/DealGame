using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Settings : MonoBehaviour
{
    public GameObject SelesaiMisiButton;
    public GameObject TerkumpulPanel;
    public GameObject kayuPanel;
    public GameObject HUDPJ1;
    public GameObject NPC1;
    public GameObject nextLevel2Button;
    public GameObject Level2Box;


    void Start()
    {
        SelesaiMisiButton.SetActive(false);
    }
    
   public void selesaiButton()
    {
        TerkumpulPanel.SetActive(false);
        kayuPanel.SetActive(false);
        
        HUDPJ1.SetActive(true);
        Time.timeScale = 1;
    }

    public void NextLevel2Button()
    {
        HUDPJ1.SetActive(false);
        NPC1.SetActive(false);
        nextLevel2Button.SetActive(false);
        Level2Box.SetActive(true);
        Time.timeScale = 1;
    }

}
