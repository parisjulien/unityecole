using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Animator animator;
    public Text nomText;
    public Text dialogueText;

    private Queue<string> phrases;

    public static DialogueManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scéne");
            return;
        }

        instance = this;
        phrases = new Queue<string>();
    }

    public void CommencerDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nomText.text = dialogue.name;

        phrases.Clear();

        foreach (string phrase in dialogue.phrase)
        {
            phrases.Enqueue(phrase);
        }

        AfficherPhraseSuivante();
    }

    public void AfficherPhraseSuivante()
    {
        if(phrases.Count == 0)
        {
            FinDialogue();
            return;
        }

        string phrase = phrases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EcrirePhrase(phrase));

    }

    IEnumerator EcrirePhrase(string phrase)
    {
        dialogueText.text = "";
        foreach ( char letre in phrase.ToCharArray())
        {
            dialogueText.text += letre;
            yield return new WaitForSeconds(0.05f);
        }

    }

    private void FinDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
