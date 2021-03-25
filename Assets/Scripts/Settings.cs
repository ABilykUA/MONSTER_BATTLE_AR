using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public TextMeshProUGUI scaleTutorial;
    public TextMeshProUGUI DisabilityTitle;
    public TextMeshProUGUI ColorBlindText;
    public TextMeshProUGUI BlurredVisionText;
    public TextMeshProUGUI BackButtonText;
    public TextMeshProUGUI PlayButtonTextBlurredVision;
    public TextMeshProUGUI BackButtonTextBlurredVision;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI AttackNum;
    public TextMeshProUGUI DefenseNum;
    public TextMeshProUGUI HealthNum;
    public TextMeshProUGUI Ability1;
    public TextMeshProUGUI Ability2;
    public TextMeshProUGUI Ability3;
    public TextMeshProUGUI level;




    public static float fontSizeTitles;
    public static float fontSizeButtons;


    public void TextSizeTitles(float fontSize)
    {
        fontSizeTitles = fontSize;

        scaleTutorial.fontSize = fontSizeTitles;
        DisabilityTitle.fontSize = fontSizeTitles;
        level.fontSize = fontSizeTitles;
        AttackNum.fontSize = fontSizeTitles - 10;
        DefenseNum.fontSize = fontSizeTitles - 10;
        HealthNum.fontSize = fontSizeTitles - 10;
        
    }
    void Update()
    {

        /*scaleTutorial.fontSize = fontSizeTitles;
        DisabilityTitle.fontSize = fontSizeTitles;
        PlayButtonText.fontSize = fontSizeButtons;
        ExitButtonText.fontSize = fontSizeButtons;
        ColorBlindText.fontSize = fontSizeButtons;
        BlurredVisionText.fontSize = fontSizeButtons;
        NormalVisionText.fontSize = fontSizeButtons;
        BackButtonText.fontSize = fontSizeButtons;
        PlayButtonTextBlurredVision.fontSize = fontSizeButtons;
        BackButtonTextBlurredVision.fontSize = fontSizeButtons;*/


    }
    void Start()
    {
        /*fontSizeTitles = 90;
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
        AttackText=*/
    }



    public void TextSizeButtons(float fontSize)
    {
        fontSizeButtons = fontSize;
        
        ColorBlindText.fontSize = fontSizeButtons;
        BlurredVisionText.fontSize = fontSizeButtons;
        BackButtonText.fontSize = fontSizeButtons;
        PlayButtonTextBlurredVision.fontSize = fontSizeButtons;
        BackButtonTextBlurredVision.fontSize = fontSizeButtons;
        Ability1.fontSize = fontSizeButtons;
        Ability2.fontSize = fontSizeButtons;
        Ability3.fontSize = fontSizeButtons;
    }
}
