using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public AudioSource SoundSlider;

     public void SetSoundSlider(float sound)
   {
        SoundSlider.volume = sound;
   }
}
