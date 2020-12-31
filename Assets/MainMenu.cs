﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;

    public void Jouer()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quiter()
    {
        Application.Quit();
    }
}
