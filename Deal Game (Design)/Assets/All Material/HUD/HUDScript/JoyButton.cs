using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    [HideInInspector]
    public bool pressed;

    public AudioSource src;
    public AudioClip sfx1;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        src.clip = sfx1;
        src.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
