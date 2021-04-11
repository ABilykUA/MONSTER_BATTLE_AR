using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    //This is a work in progress and will eventually be done with an array instead of individual things but for now this will do.
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



    //Variables 
    public static float fontSizeTitles;
    public static float fontSizeButtons;
    public int ColorBlindVal;

    //Scaling text titles of the game to support the blurred vision community
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

        


    }
    void Start()
    {
        //Set to none by default
        ColorBlindVal = 5;
        
    }


    //Scaling button text of the game to support the blurred vision community
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
    //Change value of the color blind type.
    public void HandleDropdown(int val)
    {
        ColorBlindVal = val;
    }
}
