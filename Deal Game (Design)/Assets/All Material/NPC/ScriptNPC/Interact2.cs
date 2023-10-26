using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact2 : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject dialogue2View;
    public GameObject BackGround2View;

    public GameObject NextButton;

    public TextMeshProUGUI dialogue2Text;
    
    public NPCController nPCController;

    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        dialogue2View.SetActive(false);
        BackGround2View.SetActive(false);

        sentences = new Queue<string>();
    }

    public void Next2Button()
    {
        dialogue2View.SetActive(true);
        BackGround2View.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (nPCController.isInteract)
        {
            dialogue2View.SetActive(true);
            BackGround2View.SetActive(true);
        }
        else
        {
            dialogue2View.SetActive(false);
            BackGround2View.SetActive(false);
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
        dialogue2Text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue2Text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        nPCController.isInteract = false;
    }

    public void DialogueTrigger()
    {
        StartDialogue(dialogue);
        nPCController.Interact();
    }

}
