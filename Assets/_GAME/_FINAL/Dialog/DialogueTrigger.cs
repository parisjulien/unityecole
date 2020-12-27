using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool estAPortee;

    // Update is called once per frame
    void Update()
    {
        if(estAPortee == true)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            estAPortee = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estAPortee = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.CommencerDialogue(dialogue);
    }
}
