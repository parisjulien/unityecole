using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    public int nbCle;

    public Text nbCleText;

    public static Inventaire instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scéne");
            return;
        }
        instance = this;
    }

    public void AjouterCle()
    {
        nbCle++;
        nbCleText.text = (3 - nbCle).ToString();
    }
}
