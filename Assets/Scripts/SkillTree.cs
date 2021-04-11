using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    //Damage 
    public TextMeshProUGUI DamageLevel;
    private int Damage { get; set; }
    //Defense 
    public TextMeshProUGUI DefenseLevel;
    private int Defense { get; set; }
    //Luck
    public TextMeshProUGUI LuckLevel;
    private int Luck { get; set; }
    //CriticalChance
    public TextMeshProUGUI CriticalChanceLevel;
    private int CriticalChance { get; set; }
    //CriticalDamage
    public TextMeshProUGUI CriticalDamageLevel;
    private int CriticalDamage { get; set; }
    //MaxHealth
    public TextMeshProUGUI MaxHealthText;
    private int MaxHealth { get; set; }
    //Dodge
    public TextMeshProUGUI DodgeText;
    private int Dodge { get; set; }
    //Accuracy
    public TextMeshProUGUI AccuracyLevel;
    private int Accuracy { get; set; }
    //Skill to refill uses of all abilities each round.
    public TextMeshProUGUI UseRefillText;
    private int UseRefill { get; set; }
    //Available skill points
    public TextMeshProUGUI AvailableSkillPointsText;
    public TextMeshProUGUI AvailableSkillPointsButton;
    public int AvailableSkillPoints { get; set; }

    //Other scripts.
    public GameObject controller;
    private LevelScript levelscript;

    // Start is called before the first frame update
    void Start()
    {
        levelscript = controller.GetComponent<LevelScript>();
        Damage = 0;
        Defense = 0;
        Luck = 0;
        CriticalChance = 0;
        CriticalDamage = 0;
        Accuracy = 0;
        AvailableSkillPoints = 0;
        MaxHealth = 0;
        Dodge = 0;
        UseRefill = 0;

    }

    // Update is called once per frame
    void Update()
    {
        DamageLevel.text = Damage + "/10";
        DefenseLevel.text = Defense + "/10";
        LuckLevel.text = Luck + "/5";
        CriticalChanceLevel.text = CriticalChance + "/5";
        CriticalDamageLevel.text = CriticalDamage + "/5";
        AccuracyLevel.text = Accuracy + "/5";
        AvailableSkillPointsText.text = "Available Skill Points: " + AvailableSkillPoints;
        AvailableSkillPointsButton.text = AvailableSkillPoints + "";
        MaxHealthText.text = MaxHealth + "/10";
        DodgeText.text = Dodge + "/5";
        UseRefillText.text = UseRefill + "/3";
    }
    //This function checks the limit for skills and adds skill points only if you have available skill points to spend.
    public void AddSkillPoint(int index)
    {
        
        switch (index)
        {
            case 1:
                if (Damage < 10 && AvailableSkillPoints>=1) {
                    Damage++;
                    AvailableSkillPoints--;
                    levelscript.sDamageSkill();
                }
                    
                break;
            case 2:
                if (Defense < 10 && AvailableSkillPoints >= 1)
                {
                    Defense++;
                    AvailableSkillPoints--;
                    levelscript.sDefenseSkill();
                }
                   
                break;
            case 3:
                if (Luck < 5 && AvailableSkillPoints >= 1) {
                    Luck++;
                    AvailableSkillPoints--;
                    levelscript.sLuckSkill();
                }
                    
                break;
            case 4:
                if (CriticalChance < 5 && AvailableSkillPoints >= 1)
                {
                    CriticalChance++;
                    AvailableSkillPoints--;
                    levelscript.sCriticalChanceSkill();
                }
                    
                break;
            case 5:
                if (CriticalDamage < 5 && AvailableSkillPoints >= 1)
                {
                    CriticalDamage++;
                    AvailableSkillPoints--;
                    levelscript.sCriticalDamageSkill();
                }
                    
                break;
            case 6:
                if (Accuracy < 5 && AvailableSkillPoints >= 1)
                {
                    Accuracy++;
                    AvailableSkillPoints--;
                    levelscript.sAccuracySkill();
                }
                    
                break;
            case 7:
                if (MaxHealth < 10 && AvailableSkillPoints >= 1)
                {
                    MaxHealth++;
                    AvailableSkillPoints--;
                    levelscript.sHealthSkill();
                }
                break;
            case 8:
                if (Dodge < 5 && AvailableSkillPoints >= 1)
                {
                    Dodge++;
                    AvailableSkillPoints--;
                    levelscript.sDodgeSkill();
                }
                break;
            case 9:
                if (UseRefill < 3 && AvailableSkillPoints >= 2)
                {
                    UseRefill++;
                    AvailableSkillPoints-=2;
                    levelscript.sUseRefillSkill();
                }
                break;

        }
    }
}
