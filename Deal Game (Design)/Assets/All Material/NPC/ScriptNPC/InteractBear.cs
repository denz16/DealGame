using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractBear : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject interactView;
    public GameObject dialogueView;
    public GameObject interactButton;
    public GameObject BackGroundView;

    public TextMeshProUGUI dialogueText;
    
    public BearSettings bearSettings;
    
    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        interactView.SetActive(false);
        dialogueView.SetActive(false);
        interactButton.SetActive(false);
        BackGroundView.SetActive(false);

        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bearSettings.isInteract)
        {
            interactButton.SetActive(false);
            interactView.SetActive(false);

            dialogueView.SetActive(true);
            BackGroundView.SetActive(true);
        }
        else
        {
            dialogueView.SetActive(false);
            BackGroundView.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactView.SetActive(true);
            interactButton.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactView.SetActive(false);
            interactButton.SetActive(false);

            bearSettings.isInteract = false;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        bearSettings.isInteract = false;
    }

    public void DialogueTrigger()
    {
        StartDialogue(dialogue);
        bearSettings.Interact();
    }
}
