using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OuvrirPorte : MonoBehaviour
{

    public bool estAPortee;
    public GameObject victoireUI;
    private Text interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("Interaction").GetComponent<Text>();
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

    void Update()
    {
        if (estAPortee == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(Inventaire.instance.nbCle == 3)
            {
                victoireUI.SetActive(true);
            }
        }
    }
}
