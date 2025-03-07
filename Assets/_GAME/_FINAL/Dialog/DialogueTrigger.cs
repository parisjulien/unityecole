﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool estAPortee;
    private Text interactUI;
    // Update is called once per frame

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("Interaction").GetComponent<Text>();
    }

    void Update()
    {
        if(estAPortee == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            estAPortee = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estAPortee = false;
            interactUI.enabled = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.CommencerDialogue(dialogue);
    }
}
