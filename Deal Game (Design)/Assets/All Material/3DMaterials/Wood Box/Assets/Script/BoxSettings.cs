using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxSettings : MonoBehaviour
{
    PlayerController playerController;

    public GameObject Level1Panel;
    public GameObject NextButton;
    public GameObject NextButton1;
    public AudioSource SoundSlider;

    private bool stop;
        // Use this for initialization
        void Start()
        {
            playerController = FindObjectOfType<PlayerController>(); 

            StartCoroutine(Bounce());
            StartCoroutine(Rotate());
        }

        public void GoUp()
        {
            stop = true;
            StartCoroutine(Up());
        }

        IEnumerator Rotate()
        {
            while (true)
            {
                transform.Rotate(Vector3.up * 2f);
                yield return null;
            }
        }

        IEnumerator Bounce()
        {
            while (true)
            {
                float bounceTime = 1f;

                float startY = transform.position.y;
                float endY = startY + 0.5f;

                float t = 0;
                while (t < bounceTime / 2f)
                {
                    if (stop)
                        yield break;
                    t += Time.deltaTime;
                    float fraction = t / (bounceTime / 2f);
                    float newY = Mathf.Lerp(startY, endY, fraction);
                    Vector3 newPos = transform.position;
                    newPos.y = newY;
                    transform.position = newPos;
                    yield return null;
                }

                float r = 0;
                while (r < bounceTime / 2f)
                {
                    if (stop)
                        yield break;
                    r += Time.deltaTime;
                    float fraction = r / (bounceTime / 2f);
                    float newY = Mathf.Lerp(endY, startY, fraction);
                    Vector3 newPos = transform.position;
                    newPos.y = newY;
                    transform.position = newPos;
                    yield return null;
                }
            }        
        }

        //Move up
        IEnumerator Up()
        {
            float time = 1f;

            float startY = transform.position.y;
            float endY = startY + 10f;

            float t = 0;
            while (t < time / 2f)
            {
                t += Time.deltaTime;
                float fraction = t / (time / 2f);
                float newY = Mathf.Lerp(startY, endY, fraction);
                Vector3 newPos = transform.position;
                newPos.y = newY;
                transform.position = newPos;
                yield return null;
            }

            gameObject.SetActive(false);
            GetComponent<MeshCollider>().enabled = true;
            transform.position = Vector3.zero;
            
        }


        public void LevelOneButton()
        {
            Time.timeScale = 0;
            SoundSlider.Pause();
            Level1Panel.SetActive(true);
            NextButton.SetActive(false);
            StartCoroutine(Level1Game());
            NextButton1.SetActive(true);
            
        }
        IEnumerator Level1Game()
            {
                yield return new WaitForSeconds(60);  
            }
        

        public void NextButton11()
        {
            Level1Panel.SetActive(false);
            SoundSlider.Play();
            Destroy(gameObject);
            Time.timeScale = 1;
        }

        void Update()
        {
             Vector3 direction = (playerController.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
}
