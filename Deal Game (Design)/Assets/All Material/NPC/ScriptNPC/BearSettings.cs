using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearSettings : MonoBehaviour
{
    PlayerController playerController;

    public GameObject GerbangLev1;

    Animator animator;

    [HideInInspector]
    public bool isInteract = false;

    [HideInInspector]
    public bool isCombat = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInteract)
        {
            animator.SetBool("IsTalk", false);

            if (isCombat == false)
            {
                animator.SetBool("IsSleep", true);
            }
            else if (isCombat == false)
            {
                animator.SetBool("IsSleep", false);
            }
        }
        else
            {
                GerbangLev1.SetActive(true);
                
                Vector3 direction = (playerController.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }

    }

    public void Interact()
    {
        isInteract = true;
        animator.SetBool("IsTalk", true);
    }
}
