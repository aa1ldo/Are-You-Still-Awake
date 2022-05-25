using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject continuePrompt;

    public Animator anim;

    public AudioSource typingSFX;

    public bool isOpen;

    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextSentence();
        }

        anim.SetBool("IsOpen", isOpen);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isOpen = true;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        continuePrompt.SetActive(false);
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            typingSFX.pitch = Random.Range(1.5f, 1.7f);
            typingSFX.Play();
            yield return new WaitForSeconds(0.03f);
        }
        continuePrompt.SetActive(true);
    }

    void EndDialogue()
    {
        isOpen = false;
    }
}
