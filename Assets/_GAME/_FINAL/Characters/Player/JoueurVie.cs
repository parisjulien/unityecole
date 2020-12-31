
using System;
using UnityEngine;

public class JoueurVie : MonoBehaviour
{

    public int maxPV = 100;
    public int PVCourant;

    public BarreDeVie BarreDeVie;

    public Final.PlayerController playerController;

    public Animator animator;

    void Start()
    {
        PVCourant = maxPV;
        BarreDeVie.SetMaxPV(maxPV);
    }

    void Update()
    {

    }

    public void Dommages(int nDegats)
    {
        PVCourant -= nDegats;
        BarreDeVie.SetPv(PVCourant);

        if(PVCourant <= 0)
        {
            Mort();
        }
    }

    private void Mort()
    {       
        playerController.enabled = false;
        playerController.m_MovementDirection = Vector2.zero;

        GameOverManager.instance.OnJoueurMort();
    }
}
