using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI scaleTutorial;
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI ExitButtonText;
    public TextMeshProUGUI DisabilityTitle;
    public TextMeshProUGUI ColorBlindText;
    public TextMeshProUGUI BlurredVisionText;
    public TextMeshProUGUI NormalVisionText;
    public TextMeshProUGUI BackButtonText;
    public TextMeshProUGUI PlayButtonTextBlurredVision;
    public TextMeshProUGUI BackButtonTextBlurredVision;




    public static float fontSizeTitles;
    public static float fontSizeButtons;
    public static bool Scaled=false;


    public void TextSizeTitles(float fontSize)
    {
        fontSizeTitles = fontSize;
        
        scaleTutorial.fontSize = fontSizeTitles;
        DisabilityTitle.fontSize = fontSizeTitles;
    }
    void Update()
    {
        if (Scaled == false)
        {
            scaleTutorial.fontSize = fontSizeTitles;
            DisabilityTitle.fontSize = fontSizeTitles;
            PlayButtonText.fontSize = fontSizeButtons;
            ExitButtonText.fontSize = fontSizeButtons;
            ColorBlindText.fontSize = fontSizeButtons;
            BlurredVisionText.fontSize = fontSizeButtons;
            NormalVisionText.fontSize = fontSizeButtons;
            BackButtonText.fontSize = fontSizeButtons;
            PlayButtonTextBlurredVision.fontSize = fontSizeButtons;
            BackButtonTextBlurredVision.fontSize = fontSizeButtons;
        }
        else
        {
            PlayButtonText.fontSize = fontSizeButtons-10;
            ExitButtonText.fontSize = fontSizeButtons-10;
            ColorBlindText.fontSize = fontSizeButtons-10;
            BackButtonText.fontSize = fontSizeButtons+50;
            PlayButtonTextBlurredVision.fontSize = fontSizeButtons+50;
            BackButtonTextBlurredVision.fontSize = fontSizeButtons+50;
        }
    }
    void Start()
    {
        fontSizeTitles = 90;
        fontSizeButtons = 60;
        scaleTutorial.fontSize = 90;
        DisabilityTitle.fontSize = 90;
        PlayButtonText.fontSize = 60;
        ExitButtonText.fontSize = 60;
        ColorBlindText.fontSize = 60;
        BlurredVisionText.fontSize = 60;
        NormalVisionText.fontSize = 60;
        BackButtonText.fontSize = 60;
        PlayButtonTextBlurredVision.fontSize = 60;
        BackButtonTextBlurredVision.fontSize = 60;
        
    }



    public void TextSizeButtons(float fontSize)
    {
        fontSizeButtons = fontSize;
        PlayButtonText.fontSize = fontSizeButtons;
        ExitButtonText.fontSize = fontSizeButtons;
        ColorBlindText.fontSize = fontSizeButtons;
        BlurredVisionText.fontSize = fontSizeButtons;
        NormalVisionText.fontSize = fontSizeButtons;
        BackButtonText.fontSize = fontSizeButtons;
        PlayButtonTextBlurredVision.fontSize = fontSizeButtons;
        BackButtonTextBlurredVision.fontSize = fontSizeButtons;
    }
    public void PlayGame() {
        Scaled = true;
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
