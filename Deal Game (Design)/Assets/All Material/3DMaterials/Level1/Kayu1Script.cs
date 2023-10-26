using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kayu1Script : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "Player")
        {
            ScoreScript.kayuA += 1;
            Destroy(gameObject);
        }
    }
}
