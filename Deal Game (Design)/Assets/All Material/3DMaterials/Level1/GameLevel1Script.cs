using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel1Script : MonoBehaviour
{
    public void Bunyi(AudioClip suara)
    {
        GetComponent<AudioSource>().PlayOneShot(suara, 1f);
    }
}
