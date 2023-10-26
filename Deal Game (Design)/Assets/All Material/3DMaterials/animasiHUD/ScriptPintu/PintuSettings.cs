using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuSettings : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Door")
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            if(Input.GetKeyDown(KeyCode.E))
            anim.SetTrigger("BukaTutup");
        }
    }
}
