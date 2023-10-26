using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogoGame());
    }
    IEnumerator LogoGame()
    {
        yield return new WaitForSeconds(10);
        Application.LoadLevel("Main");
    }

}
