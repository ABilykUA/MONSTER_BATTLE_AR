﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene(0);
    }


    public void ExitGame()
    {
        Application.Quit();

    }



}
