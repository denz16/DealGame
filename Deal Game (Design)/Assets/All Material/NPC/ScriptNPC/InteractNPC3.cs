using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC3 : MonoBehaviour
{
    public NPC3Settings npc3Settings;

    public GameObject interact3View;
    public GameObject interact3Button;
    
    
    // Start is called before the first frame update
    void Start()
    {
        interact3View.SetActive(false);
        interact3Button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact3View.SetActive(true);
            interact3Button.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact3View.SetActive(false);
            interact3Button.SetActive(false);
        }
    }
}
