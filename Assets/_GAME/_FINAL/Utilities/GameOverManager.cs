using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    public void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }



    public void OnJoueurMort()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryBouton()
    {
        //Recharger la scéne
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        gameOverUI.SetActive(false);
    }

    public void MenuPrinBouton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuiterBouton()
    {
        Application.Quit();
    }

}
