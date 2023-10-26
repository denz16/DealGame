using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text text;
    public static int kayuA = 0;
    public GameObject TerkumpulPanel;
    public GameObject SelesaiMisiButton;

    void Start()
    {
        text = GetComponent<Text>();
        TerkumpulPanel.SetActive(false);
    }

    void Update()
    {
       text.text = "Kayu Terkumpul :" + kayuA.ToString();

       if(kayuA > 6)
       {
            Time.timeScale = 0;
            TerkumpulPanel.SetActive(true);
            SelesaiMisiButton.SetActive(true);
       }
    }

}
