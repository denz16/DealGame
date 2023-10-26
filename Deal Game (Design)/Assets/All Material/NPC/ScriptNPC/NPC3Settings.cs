using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC3Settings : MonoBehaviour
{
    PlayerController playerController;

    public GameObject AljabarPanel;
    public GameObject interact3Button;
    public GameObject endSMissionButton;
    public GameObject MisiSelesai1Panel;
    public GameObject nextLevel2Button;
    public AudioSource SoundSlider;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

        public void Int3Button()
        {
            Time.timeScale = 0;
            SoundSlider.Pause();
            AljabarPanel.SetActive(true);
            interact3Button.SetActive(false);
            StartCoroutine(SMissionGame());
            endSMissionButton.SetActive(true);
            
        }
        IEnumerator SMissionGame()
            {
                yield return new WaitForSeconds(60);  
            }
        

        public void EndMissionButton()
        {
            AljabarPanel.SetActive(false);
            SoundSlider.Play();
            Destroy(gameObject);
            MisiSelesai1Panel.SetActive(true);
            nextLevel2Button.SetActive(true);
        }

}
