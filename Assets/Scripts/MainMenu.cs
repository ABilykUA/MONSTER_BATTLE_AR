using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //Start the game
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    //Stops and closes the game 
    public void ExitGame()
    {
        Application.Quit();

    }
    //Opens a link to our video demonstration which is pretty much a tutorial about the game.
    public void openTutorialURL()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=CkWt37SjU3Y");
    }


}
