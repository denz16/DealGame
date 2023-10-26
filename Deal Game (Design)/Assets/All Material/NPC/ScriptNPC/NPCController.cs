using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform startTarget;
    public Transform endTarget;

    public GameObject StartObject;
    public GameObject kayuPanel;

    PlayerController playerController;
    NavMeshAgent agent;
    Animator animator;

    [HideInInspector]
    public bool isInteract = false;

    [HideInInspector]
    public bool isArrived = false;

    [HideInInspector]
    public float distanceThreshold = 0.2f; // Adjust this threshold to your needs

    private float defaultRandomOffset = 10f;
    private float currentRandomOffset;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        playerController = FindObjectOfType<PlayerController>();

        agent.transform.position = startTarget.position;
        agent.SetDestination(endTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInteract)
        {
            animator.SetBool("IsTalk", false);
            agent.enabled = true;

            if (isArrived == false)
            {
                agent.SetDestination(endTarget.position);
            }
            else if (isArrived == true)
            {
                agent.SetDestination(startTarget.position);
            }

            if (agent.velocity.magnitude >= 0.5f)
            {
                animator.SetBool("IsWalk", true);
            }
            
        }
        else
            {
                agent.enabled = false;

                StartObject.SetActive(true);
                kayuPanel.SetActive(true);


                Vector3 direction = (playerController.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }

    }

    public void Interact()
    {
        isInteract = true;
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsTalk", true);
    }
}
