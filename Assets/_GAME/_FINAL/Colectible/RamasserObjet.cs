
using UnityEngine;

public class RamasserObjet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventaire.instance.AjouterCle();
            Destroy(gameObject);
        }
    }
}
