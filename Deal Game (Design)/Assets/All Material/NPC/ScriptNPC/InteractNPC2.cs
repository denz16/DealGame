using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC2 : MonoBehaviour
{
    public NPC2Settings npc2Settings;

    public GameObject interact2Button;
    
    
    // Start is called before the first frame update
    void Start()
    {
        interact2Button.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact2Button.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact2Button.SetActive(false);
        }
    }
}
