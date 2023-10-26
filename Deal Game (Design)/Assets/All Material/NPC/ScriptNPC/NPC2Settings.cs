using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC2Settings : MonoBehaviour
{
    PlayerController playerController;

    public GameObject Histori1Panel;
    public GameObject interact2Button;
    public GameObject endSMissionButton;
    public GameObject NPC3;
    public AudioSource SoundSlider;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

        public void Int2Button()
        {
            Time.timeScale = 0;
            SoundSlider.Pause();
            Histori1Panel.SetActive(true);
            interact2Button.SetActive(false);
            StartCoroutine(SMissionGame());
            endSMissionButton.SetActive(true);
            
        }
        IEnumerator SMissionGame()
            {
                yield return new WaitForSeconds(60);  
            }
        

        public void EndMissionButton()
        {
            Histori1Panel.SetActive(false);
            SoundSlider.Play();
            Destroy(gameObject);
            NPC3.SetActive(true);
            Time.timeScale = 1;
        }

}
