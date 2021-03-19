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

    public void TextSizeTitles(float fontSize)
    {
        fontSizeTitles = fontSize;
        fontSizeTitles = fontSizeTitles;
        scaleTutorial.fontSize = fontSizeTitles;
        DisabilityTitle.fontSize = fontSizeTitles;

    }
    void Update()
    {
        fontSizeTitles = fontSizeTitles;
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
    void Start()
    {
        fontSizeTitles = fontSizeTitles;
        scaleTutorial.fontSize = 90;
        DisabilityTitle.fontSize = 90;
        PlayButtonText.fontSize = fontSizeButtons;
        ExitButtonText.fontSize = fontSizeButtons;
        ColorBlindText.fontSize = fontSizeButtons;
        BlurredVisionText.fontSize = fontSizeButtons;
        NormalVisionText.fontSize = fontSizeButtons;
        BackButtonText.fontSize = fontSizeButtons;
        PlayButtonTextBlurredVision.fontSize = fontSizeButtons;
        BackButtonTextBlurredVision.fontSize = fontSizeButtons;
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
