
using UnityEngine;

public class JoueurVie : MonoBehaviour
{

    public int maxPV = 100;
    public int PVCourant;

    public BarreDeVie BarreDeVie;

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
    }

}
