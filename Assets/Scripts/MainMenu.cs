using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI scaleTutorial;
    public TextMeshProUGUI MainMenuTitle;
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI ExitButtonText;
    public TextMeshProUGUI DisabilityTitle;
    public TextMeshProUGUI ColorBlindText;
    public TextMeshProUGUI BlurredVisionText;
    public TextMeshProUGUI NormalVisionText;
    public TextMeshProUGUI BackButtonText;

    public void TextSize(float fontSize)
    {
        scaleTutorial.fontSize = fontSize+15;
        MainMenuTitle.fontSize = fontSize+15;
        PlayButtonText.fontSize = fontSize;
        ExitButtonText.fontSize = fontSize;
        DisabilityTitle.fontSize = fontSize+15;
        ColorBlindText.fontSize = fontSize;
        BlurredVisionText.fontSize = fontSize;
        NormalVisionText.fontSize = fontSize;
        BackButtonText.fontSize = fontSize;

    }
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
