using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBox : MonoBehaviour
{

    public GameObject interactView;
    public GameObject interactButton;
    
    public BoxSettings boxSettings;
    
    // Start is called before the first frame update
    void Start()
    {
        interactView.SetActive(false);
        interactButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactView.SetActive(true);
            interactButton.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactView.SetActive(false);
            interactButton.SetActive(false);
        }
    }

}
