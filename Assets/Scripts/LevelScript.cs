
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LevelScript : MonoBehaviour
{
    public GameObject UI;

    public GameObject VictoryRoyal;
    public GameObject SettingsScreen;

    public GameObject DefeatUI;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject Boss;
    public GameObject Skelly;

    public GameObject replaceAbilityButton;
    public GameObject replaceAbility1;
    public GameObject replaceAbility2;
    public GameObject replaceAbility3;
    
    public TextMeshProUGUI replaceAbilityText1;
    public TextMeshProUGUI replaceAbilityText2;
    public TextMeshProUGUI replaceAbilityText3;


    public TextMeshPro EnemyHealth;
    public TextMeshPro EnemyType;

    //Game UI
    public TextMeshProUGUI mHealth;
    public TextMeshProUGUI mAttack;
    public TextMeshProUGUI mDefense;
    public TextMeshProUGUI mType;

    //Level
    public TextMeshProUGUI mTitle;

    //Lose UI 
    public TextMeshProUGUI LmLevel;
    public TextMeshProUGUI HighscoreText;


    //AbilityInfoUI
    public TextMeshProUGUI AbHeal;
    public TextMeshProUGUI AbDamage;
    public TextMeshProUGUI AbType;
    public TextMeshProUGUI AbAccuracy;
    public GameObject AbilityInfoUI;


    //Win Ui  
    public TextMeshProUGUI WHealth;
    public TextMeshProUGUI WAttack;
    public TextMeshProUGUI WDefense;

    //AbilityButtonsText
    public TextMeshProUGUI Ability1;
    public TextMeshProUGUI Ability2;
    public TextMeshProUGUI Ability3;

    //WinUIAbilitys
    public TextMeshProUGUI AHeal;
    public TextMeshProUGUI ADamage;
    public TextMeshProUGUI AType;
    public TextMeshProUGUI AName;
    public TextMeshProUGUI AUses;
    public TextMeshProUGUI AAccuracy;
    public TextMeshProUGUI ADescription;

    //Potion added win UI
    public TextMeshProUGUI APotion;

    public TextMeshPro EnemyGetDamage;
 
 
    public TextMeshProUGUI HeroGetDamage;

    //Backpack Heals
    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;
    public GameObject potion4;

    //change the initial values to 0
    private int potion1Uses = 2;
    private int potion2Uses = 1;
    private int potion3Uses = 1;
    private int potion4Uses = 2;

	// potions
    public TextMeshProUGUI potion1text;
    public TextMeshProUGUI potion2text;
    public TextMeshProUGUI potion3text;
    public TextMeshProUGUI potion4text;


    //animations
    public GameObject PopupHeroText;
    public GameObject PopupHeroHealText;
    public GameObject FloatingText;


    public GameObject ObjrctSkely;
    public GameObject Player;

    
    private Animator Skely;
    private Animator SkelyPlayer;

    private Animator FloatingTxt;
    private Animator PopupHeroTxt;
    private Animator PopupHeroAnimation;
    private Animator BossAnimator;


    //All Abilities
    private Abilities[] abilities = { null, null, null, null, null, null, null, null,null,null,null,null,null,null,null,null };

    private Abilities EmptyAbility = new Abilities(0, " ", 0, 0, " ", " ",0,"");

    private Abilities newAbility = new Abilities(0, " ", 0, 0, " ", " ",0,"");

    private string[] Type = { "Water", "Grass", "Fire" };


    //max stats
    private double MaxPlayer;


    private double MaxEnemy;

    private double MaxBoss;


    // gaind during lvl 
    private int GaindHealth = 0 ;

    private int GainAttack = 0 ;

    private int GainDefence = 0;

    private string TypeMe;

    private int Level = 1;

    

    //for switch
    private int SwitchCounter = 1;

    //GG for the player
    private Entity GG;

    //Enemy
    private Entity SIMP;

    private Settings settings;
    public GameObject controller;

    //Skill Tree
    private int sLuck=0;
    private int sAccuracy=0;
    private int sCriticalChance=0;
    private double sCriticalDamage=0.0;
    private int sHealth = 0;
    private int sDodge = 0;
    private int sUseRefill = 0;

    public TextMeshProUGUI SkillTreeInfo;
    SkillTree skillTree;

    private void GenerateAbilities()
    {
    
        abilities[0] = new Abilities(40, "Fire", 0, 15, "Fire bolt", "Grass",100,"A weak starting ability");
        abilities[1] = new Abilities(40, "Water", 0, 15, "Water gun", "Fire",100, "A weak starting ability");
        abilities[2] = new Abilities(40, "Grass", 0, 15, "Grass slap", "Water",100, "A weak starting ability");
        abilities[3] = new Abilities(50, "Fire", 0, 12, "Flame Wheel", "Grass",95,"");
        abilities[4] = new Abilities(65, "Water", 0, 10, "Tsunami", "Fire",80,"");
        abilities[5] = new Abilities(75, "Grass", 0, 7, "Branch slam", "Water",85,"");
        abilities[6] = new Abilities(0, "Grass", 40, 5, "Synthesis", "Water",100, "This ability only heals.");
        abilities[7] = new Abilities(50, "Fire", 5, 10, "Flare Blitz", "Grass",95, "");
        abilities[8] = new Abilities(50, "Grass", 5, 10, "Solar Beam", "Water",95, "");
        abilities[9] = new Abilities(80, "Water", 5, 5, "Wave Force", "Fire",70, "");
        abilities[10] = new Abilities(65, "Chameleon", 0, 7, "Chameleon Whip", "Fire",85,"Adjusts to always counter the enemy type.");
        abilities[11] = new Abilities(50, "Chameleon", 10, 5, "Chameleon Glare", "Fire", 80, "Adjusts to always counter the enemy type. Also heals.");
        abilities[12] = new Abilities(200, "Water", 0, 3, "Poseidon's Fury", "Fire", 30, "A high damage low accuracy ability made for performing miracles.");
        abilities[13] = new Abilities(75, "Fire", 10, 7, "Implosion", "Grass", 50, "The enemy violently implodes inwards dealing huge fire damage.");
        abilities[14] = new Abilities(75, "Water", 0, 10, "Moonchild Slam", "Fire", 70, "Blessed by an ability from the stars");
        abilities[15] = new Abilities(60, "Grass", 28, 10, "Amazons Wrath", "Water", 70, "Call the Amazons to your rescue.");
    }


    private void ColorChange(Entity GG)
    {

        GameObject[] buttons = { Button1, Button2, Button3 };
        if (settings.ColorBlindVal == 0)
        {
            
            for (int i = 0; i < buttons.Length; i++)
            {
                if (GG.abilities[i].type == "Fire")
                {
                    buttons[i].GetComponent<Image>().color = new Color(255,192,0);
                }
                else if (GG.abilities[i].type == "Water")
                {
                    buttons[i].GetComponent<Image>().color = new Color(0, 115, 255);
                }
                else if (GG.abilities[i].type == "Grass")
                {
                    buttons[i].GetComponent<Image>().color = new Color(255,0,0);
                }
            }
        }
        else if(settings.ColorBlindVal == 1)
        {
            
            for (int i = 0; i < buttons.Length; i++)
            {
                if (GG.abilities[i].type == "Fire")
                {
                    buttons[i].GetComponent<Image>().color = new Color(48, 255, 0);
                }
                else if (GG.abilities[i].type == "Water")
                {
                    buttons[i].GetComponent<Image>().color = new Color(255, 0, 221);
                }
                else if (GG.abilities[i].type == "Grass")
                {
                    buttons[i].GetComponent<Image>().color = new Color(255, 0, 0);
                }
            }
        }
        else if (settings.ColorBlindVal == 2)
        {

            for (int i = 0; i < buttons.Length; i++)
            {
                if (GG.abilities[i].type == "Fire")
                {
                    buttons[i].GetComponent<Image>().color = new Color(255, 0, 0);
                }
                else if (GG.abilities[i].type == "Water")
                {
                    buttons[i].GetComponent<Image>().color = new Color(0, 255, 58);
                }
                else if (GG.abilities[i].type == "Grass")
                {
                    buttons[i].GetComponent<Image>().color = new Color(0, 38, 255);
                }
            }
        }
        else
        {
            
            for (int i = 0; i < buttons.Length; i++)
            {
                if (GG.abilities[i].type == "Fire")
                {
                    buttons[i].GetComponent<Image>().color = Color.red;
                }
                else if (GG.abilities[i].type == "Water")
                {
                    buttons[i].GetComponent<Image>().color = Color.blue;
                }
                else if (GG.abilities[i].type == "Grass")
                {
                    buttons[i].GetComponent<Image>().color = Color.green;
                }
            }
        }
    }



    private void UpdateUI(Entity SIMP, Entity GG) {
        //player
        mHealth.SetText((int)GG.Health + "/" + MaxPlayer);
        mDefense.SetText(""+GG.Defense);
        mAttack.SetText(""+GG.Attack);

        ColorChange(GG);
        for (int i = 0; i < 3; i++)
        {
            if (GG.abilities[i].name == "Chameleon Whip" || GG.abilities[i].name=="Chameleon Glare")
            {
                GG.abilities[i].type = SIMP.Counter;
                GG.abilities[i].counter = SIMP.Type;
            }
        }

        //enemy or boss decision
        if (Level % 5 == 0)
        {
            EnemyHealth.SetText("Health: " + (int)SIMP.Health + "/" + MaxBoss);
            Debug.Log(SIMP.Health + " " + MaxBoss + " " + SIMP.Type + " "  + SIMP.Attack);

        }
        else
        {
            EnemyHealth.SetText("Health: " + (int)SIMP.Health + "/" + MaxEnemy);
        }
            

        EnemyType.SetText("Type: " + SIMP.Type);

        //Level
        mTitle.SetText("Level: " + Level);

        //DUI 
        LmLevel.SetText("You made it to level: " + Level);
        HighscoreText.SetText("Top Level Reached: " + GetHighscore());
        //Type
        mType.SetText("Your Type: " + GG.Type);

        //WUI
        WHealth.SetText("Health: +" + GaindHealth);
        WAttack.SetText("Attack: +" + GainAttack);
        WDefense.SetText("Defense: +" + GainDefence);

        //Current Abilities
        Ability1.text = GG.abilities[0].name + "   " + GG.abilities[0].uses + "/" + GG.abilities[0].MaxUses;
        Ability2.text = GG.abilities[1].name + "   " + GG.abilities[1].uses + "/" + GG.abilities[1].MaxUses;
        Ability3.text = GG.abilities[2].name + "   " + GG.abilities[2].uses + "/" + GG.abilities[2].MaxUses;

        //newAbility
        ADamage.SetText("Damage: " + newAbility.damage);
        AType.SetText("Type: " + newAbility.type);
        AName.SetText("Name: " + newAbility.name);
        AUses.SetText("Uses: " + newAbility.uses);
        AHeal.SetText("Heal: " + newAbility.heal+"%");
        AAccuracy.SetText("Accuracy: "+newAbility.SuccessRate);
        ADescription.SetText(newAbility.description);

        
       

    }

    public void HealthPotions(int potionType)
    {
        
        switch (potionType)
        {
            case 1:
                if (potion1Uses > 0)
                {

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + 180);
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                  
                    if (MaxPlayer >= (GG.Health + 180))
                    {
                        GG.Health += 180;
                        potion1Uses--;
                        SwitchCounter = 2;
                    }
                    else
                    {
                        GG.Health = MaxPlayer;
                        potion1Uses--;
                        SwitchCounter = 2;
                    }
					
                }
                break;
            case 2:
                if (potion2Uses > 0)
                {

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + 260);
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                
                    if (MaxPlayer >= (GG.Health + 260))
                    {
                        GG.Health += 260;
                        potion2Uses--;
                        SwitchCounter = 2;
                    }
                    else
                    {
                        GG.Health = MaxPlayer;
                        potion2Uses--;
                        SwitchCounter = 2;
                    }

                }
                break;
            case 3:
                if (potion3Uses > 0)
                {

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + 380);
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                

                    if (MaxPlayer >= (GG.Health + 380))
                    {
                        GG.Health += 380;
                        potion3Uses--;
                        SwitchCounter = 2;
                    }
                    else
                    {
                        GG.Health = MaxPlayer;
                        potion3Uses--;
                        SwitchCounter = 2;
                    }

                }
                break;
            case 4:
                if (potion4Uses > 0)
                {

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + 5 +" uses on all abilities");
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);


                    for (int i = 0; i < 3; i++) {
                        if (GG.abilities[i].uses + 5 < GG.abilities[i].MaxUses)
                            GG.abilities[i].uses += 5;
                        else
                            GG.abilities[i].uses = GG.abilities[i].MaxUses;
                    }
                    potion4Uses--;
                    SwitchCounter = 2;
                    

                }
                break;
        }
        potion1text.text = "" + potion1Uses;
        potion2text.text = "" + potion2Uses;
        potion3text.text = "" + potion3Uses;
        potion4text.text = "" + potion4Uses;
    }

    public void AttackSlot1()
    {
        PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
        PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
        Attacking(GG.abilities[0]);
        if (GG.abilities[0].uses > 0)
            GG.abilities[0].uses -= 1;
    }
    public void AttackSlot2()
    {
        PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
        PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
        Attacking(GG.abilities[1]);
        if (GG.abilities[1].uses > 0)
            GG.abilities[1].uses -= 1;
    }
    public void AttackSlot3()
    {
       PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
       PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
       Attacking(GG.abilities[2]);
       if(GG.abilities[2].uses > 0)
            GG.abilities[2].uses -= 1;
            
        
    }
    
    private void Attacking(Abilities ability)
    {
        //animations
        SkelyPlayer.SetTrigger("Attack");
        
        double heal;
        double damage=0;
        double crit = 1;
        int HitOrMiss = Random.Range(0, 101);
        
        if (ability.uses <= 0)
        {

            damage = EntityIsHit(3, ability, SIMP.Type,SIMP.Counter, SIMP.Defense, GG.Attack, ref crit,true);


            if (crit >= 1.5 && crit<2.0)
            {
                EnemyGetDamage.SetText("-" + (int)damage + " Crit");
            }
            else if (crit >= 2.0)
            {

                EnemyGetDamage.SetText("-" + (int)damage + " Mega Crit");

            }
            else
            {
                EnemyGetDamage.SetText("-" + (int)damage);
            }
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
            SIMP.Hit(damage);

            PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
            PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
        }
        else if (ability.uses > 0 && SIMP.Type == ability.type)
        {

            if (HitOrMiss <= ability.SuccessRate+sAccuracy)
            {
                damage = EntityIsHit(1, ability, SIMP.Type,SIMP.Counter, SIMP.Defense, GG.Attack, ref crit,true);

                if (crit >= 1.5 && crit<2.0)
                {
                    EnemyGetDamage.SetText("-" + (int)damage + " Crit");
                }
                else if (crit >= 2.0)
                {

                    EnemyGetDamage.SetText("-" + (int)damage + " Mega Crit");

                }
                else
                {
                    EnemyGetDamage.SetText("-" + (int)damage);
                }
            }else
                EnemyGetDamage.SetText("Attack Missed!");

            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
            SIMP.Hit(damage);
            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    heal = (MaxPlayer * ability.heal) / 100;
                    GG.Health += heal;
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (GG.Health > MaxPlayer)
                    {
                        GG.Health = MaxPlayer;
                        
                        
                    }

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + (int)heal);
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                }
            }

            
        }
        else
        {
            if (HitOrMiss <= ability.SuccessRate + sAccuracy)
            {
                damage = EntityIsHit(2, ability, SIMP.Type,SIMP.Counter, SIMP.Defense, GG.Attack, ref crit,true);


                if (crit >= 1.5 && crit<2.0)
                {
                    EnemyGetDamage.SetText("-" + (int)damage + " Crit");
                }
                else if (crit >= 2.0)
                {

                    EnemyGetDamage.SetText("-" + (int)damage + " Mega Crit");

                }
                else
                {
                    EnemyGetDamage.SetText("-" + (int)damage);
                }
            }else
                EnemyGetDamage.SetText("Attack Missed!");
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);

            SIMP.Hit(damage);

            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    heal = (MaxPlayer * ability.heal) / 100;
                    GG.Health += heal;
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (GG.Health > MaxPlayer)
                    {
                        GG.Health = MaxPlayer;


                       
                    }

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + (int)heal);
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                }
            }
        }

        WinOrLoseCheck(2);

    }

    private void EnemyAttacking()
    {
        Skely.SetTrigger("IsDamage");

        BossAnimator.SetTrigger("BossTrigger");
        
        Abilities temp;
        
        StartCoroutine(ExampleCoroutine());
        if (Level == 1) 
        { 
            temp = SIMP.GetAbilities(0);
        }
        else if (Level == 2)
        {
            temp = SIMP.GetAbilities(Random.Range(0,2));
        }
        else
        {
            temp = SIMP.GetAbilities(Random.Range(0, 3));
        }
       

        double damage=0;

        double crit = 1;
        int HitOrMiss = Random.Range(0, 101);
        Debug.Log("Enemy Ability name: " + temp.name);
        if (GG.Type == temp.type)
        {

            int percentForDodge = Random.Range(1, 101);
            if (percentForDodge <= sDodge)
            {
                HeroGetDamage.SetText("Attack Dodged!");
            }
            else
            {
                if (HitOrMiss <= temp.SuccessRate)
                {
                    damage = EntityIsHit(1, temp, GG.Type, GG.Counter, GG.Defense, SIMP.Attack, ref crit, false);
                    if (crit >= 1.5 && crit < 2.0)
                    {
                        HeroGetDamage.SetText("-" + (int)damage + " Crit");
                    }
                    else if (crit >= 2.0)
                    {

                        HeroGetDamage.SetText("-" + (int)damage + " Mega Crit");

                    }
                    else
                    {
                        HeroGetDamage.SetText("-" + (int)damage);
                    }
                }
                else
                    HeroGetDamage.SetText("Attack Missed!");
            }
            


            GG.Hit(damage);
            
        }
        else
        {
            int percentForDodge = Random.Range(0, 101);
            if (percentForDodge <= sDodge)
            {
                HeroGetDamage.SetText("Attack Dodged!");
            }
            else
            {
                if (HitOrMiss <= temp.SuccessRate)
                {
                    damage = EntityIsHit(2, temp, GG.Type, GG.Counter, GG.Defense, SIMP.Attack, ref crit, false);


                    if (crit >= 1.5 && crit < 2.0)
                    {
                        HeroGetDamage.SetText("-" + (int)damage + " Crit");
                    }
                    else if (crit >= 2.0)
                    {

                        HeroGetDamage.SetText("-" + (int)damage + " Mega Crit");

                    }
                    else
                    {
                        HeroGetDamage.SetText("-" + (int)damage);
                    }
                }
                else
                    HeroGetDamage.SetText("Attack Missed!");
            }
            

            GG.Hit(damage);
        }
            //If ability heals
            if (temp.heal > 0)
            {
                if (SIMP.Health < MaxEnemy)
                {
                    SIMP.Health += ((MaxEnemy * temp.heal) / 100 );
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (SIMP.Health > MaxEnemy)
                    {
                        SIMP.Health = MaxEnemy;
                    }
                
                }
            }
    

        StopCoroutine(ExampleCoroutine());

        WinOrLoseCheck(1);
    }

    private double EntityIsHit(int damageType, Abilities ability, string targetType,string targetCounter, int def, int charAttack,ref double crit,bool player) 
    {
        double PlusMinus = Random.Range(-5, 5);
        double modifier = (100.0 / (100.0 + def));
        int randomizer = Random.Range(0, 101);
        
        if (player)
        {
            if (randomizer <= 10 + sCriticalChance)
            {
                Debug.Log("Player.Randomizer for crit: " + randomizer);
                crit = 1.5+ (1.5 * (sCriticalDamage / 100.0));
                Debug.Log("Crit multiplier: "+crit);
            }
            else if (randomizer > 10 + sCriticalChance && randomizer <= 13 + (sCriticalChance * 2))
            {
                Debug.Log("Player.Randomizer for crit: " + randomizer);
                crit = 2.0 + (2.0 * (sCriticalDamage / 100.0));
                Debug.Log("MEGACrit! multiplier: "+crit);
            }
        }
        else
        {
            
            if (randomizer <= 10)
            {
                Debug.Log("Enemy. Randomizer for crit: " + randomizer);
                crit = 1.5;
                Debug.Log("Crit!");
            }
            else if (randomizer > 10 && randomizer <= 13)
            {
                Debug.Log("Enemy.Randomizer for crit: " + randomizer);
                crit = 2.0;
                Debug.Log("MEGACrit!");
            }
        }
        
        
        
        switch (damageType)
        {
            
            case 1:
                // Add a pop up
                if (ability.damage == 0)
                {
                    return 0; 
                }
                return ((((ability.damage + PlusMinus) * charAttack) / 100)) * crit;
            //Deals Damage
            case 2:
                if (ability.damage == 0)
                {
                    return 0;
                }
                if (ability.counter == targetType)
                {
                    return (((((ability.damage + PlusMinus) * charAttack) / 100) * modifier)*2)*crit;
                }
                else if(ability.type==targetCounter)
                {
                    return (((((ability.damage + PlusMinus) * charAttack) / 100) * modifier)/2)*crit;
                }else
                    return ((((ability.damage + PlusMinus) * charAttack) / 100) * modifier) * crit;

            case 3:
                if (ability.damage == 0)
                {
                    return 0;
                }
                return (((10 * charAttack) / 100) * modifier) * crit;
            
            default:
                Debug.Log("WHERE IS THE DAMAGE??");
                return 0;
        }
    }
   
    //generates stats on the first frame 
    private void GenerateStats() {
        //whatever type you get for enemy or you you get the same type of ability
        TypeMe = Type[Random.Range(0, Type.Length)];
        
		int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
        int H = Random.Range(200, 301);
        string counterType;
        if (TypeMe == "Fire")
            counterType = "Water";
        else if (TypeMe == "Water")
            counterType = "Grass";
        else if (TypeMe == "Grass")
            counterType = "Fire";
        else
            counterType = "";
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].type == TypeMe)
            {
                
                GG = new Entity(H, D, A, TypeMe,counterType, abilities[i], EmptyAbility);
                Ability1.text = abilities[i].name;
                break;
            }
        }
        //set MaxHealth
        MaxPlayer = GG.Health;

    }
    private void GenerateEnemyStats()
    {
        string TypeEnemy = Type[Random.Range(0, Type.Length)];
        string counterType;
        if (TypeEnemy == "Fire")
            counterType = "Water";
        else if (TypeEnemy == "Water")
            counterType = "Grass";
        else if (TypeEnemy == "Grass")
            counterType = "Fire";
        else
            counterType = "";
        
        for (int i = 0; i < Type.Length; i++)
        {

            if (GG.Type == counterType)
                break;
            else if (GG.Type == TypeEnemy)
                break;
            else
            {
                TypeEnemy = Type[Random.Range(0, Type.Length)];
                i = 0;
            }

        }
		
        int A = Random.Range(40, 61);
        int D = Random.Range(10, 31);
        int H = Random.Range(70, 151);

        

        for (int i = 0; i < 3; i++)
        {
            if (abilities[i].type == TypeEnemy && abilities[i].damage != 0)
            {
                SIMP = new Entity(H, D, A, TypeEnemy, counterType, abilities[i], EmptyAbility);
            }
        }
		
        MaxEnemy = SIMP.Health;
    }
    //Scaling enemy stats
    private void GenerateNextEnemy()
    {
        Abilities tempA;
        string TypeEnemy = Type[Random.Range(0, Type.Length)];
        //boss fight every 5 levels
        int A, D, H;
        if (Level % 5 == 0)
        {
            Boss.SetActive(true);
            Skelly.SetActive(false);
            A = (GG.Attack - 10);
            D = (GG.Defense - 5);
            H = (int)(GG.Health + 100);
            MaxBoss = (GG.Health + 100);

        }
        else
        {
            Boss.SetActive(false);
            Skelly.SetActive(true);

            GainAttack = Random.Range(10, 21);

            GainDefence = Random.Range(5, 11);

            GaindHealth = Random.Range(40, 71);

            SIMP.Health = MaxEnemy;
            A = SIMP.Attack + GainAttack;
            D = SIMP.Defense + GainDefence;
            H = (int)(SIMP.Health + GaindHealth);
            MaxEnemy = SIMP.Health + GaindHealth;
            
        }

        
        string counterType;
        if (TypeEnemy == "Fire")
            counterType = "Water";
        else if (TypeEnemy == "Water")
            counterType = "Grass";
        else if (TypeEnemy == "Grass")
            counterType = "Fire";
        else
            counterType = "";

       

        if (Level == 2)
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[i];
                if (tempA.type == TypeEnemy && tempA.damage != 0)
                {
                    SIMP = new Entity(H, D, A, TypeEnemy, counterType, abilities[i], EmptyAbility);
                    break;
                }
            }
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[i];
                if (tempA.type == TypeEnemy && tempA.damage != 0)
                {
                    SIMP.SetAbilities(tempA, 1);
                    break;
                }
            }
        }
        else
        {
            //level 3 and above enemies have 3 abilities
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[i];
                if (tempA.type == TypeEnemy && tempA.damage != 0)
                {
                    SIMP = new Entity(H, D, A, TypeEnemy, counterType, abilities[i], EmptyAbility);
                    break;
                }
            }
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[i];
                if (tempA.type == TypeEnemy && tempA.damage != 0 && SIMP.GetAbilities(0).name != tempA.name)
                {
                    SIMP.SetAbilities(tempA, 1);
                    break;
                }
            }
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[i];
                if (tempA.type == TypeEnemy && tempA.damage != 0 && SIMP.GetAbilities(0).name != tempA.name && SIMP.GetAbilities(1).name != tempA.name)
                {
                    SIMP.SetAbilities(tempA, 2);
                    break;
                }
            }
            
            
        }
    }
    
    private void AddStats() {

        
        if(Level % 5 == 0)
        {
            skillTree.AvailableSkillPoints+=2;
        }
        else
            skillTree.AvailableSkillPoints++;

        Level++;
        mTitle.SetText(Level.ToString());
        for (int i = 0; i < 3; i++)
        {
            if ((GG.abilities[i].uses + sUseRefill) <= GG.abilities[i].MaxUses)
                GG.abilities[i].uses += sUseRefill;
            else
                GG.abilities[i].uses = GG.abilities[i].MaxUses;
        }
        GainAttack = Random.Range(10, 21);

        GainDefence = Random.Range(5, 11);

        GaindHealth = Random.Range(50, 81);

        GG.Health = MaxPlayer;

        GG.Attack += GainAttack;
        GG.Defense += GainDefence;
        GG.Health += GaindHealth;

        MaxPlayer = GG.Health;
        //Adapting the chameleon ability
        
        

        //chooses random new ability
        bool added = false;
            bool maxCapacity = false;
            for (int i = 0; i < abilities.Length; i++)
            {

            newAbility = abilities[Random.Range(0, abilities.Length)];
            if(newAbility.type == "Chameleon")
            {
                newAbility.type = SIMP.Counter;
                newAbility.counter = SIMP.Type;
            }
            Debug.Log(newAbility.name);
                if (newAbility.name != GG.abilities[0].name 
                && newAbility.name != GG.abilities[1].name 
                && newAbility.name != GG.abilities[2].name)
                {
                Debug.Log("If exists");
                    if (GG.abilities[1].name == " ")
                    {
                        
                        //GG.abilities[1] = newAbility;
                        Debug.Log("Activate new button 1");
                        Button2.SetActive(true);
                        GG.SetAbilities(newAbility, 1);
                        added = true;
                        Ability2.text = newAbility.name;


                    }
                    else if (GG.abilities[2].name == " " && added != true)
                    {
                        
                        Debug.Log("Activate new button 2");
                        Button3.SetActive(true);
                        GG.SetAbilities(newAbility, 2);
                        added = true;
                        Ability3.text = newAbility.name;
                    }
                    else 
                    { 
                        maxCapacity = true;
                    }
                    
                
                if (maxCapacity)
                {
                    
             
                    replaceAbilityText1.text = GG.abilities[0].name + "   " + GG.abilities[0].uses + "/" + GG.abilities[0].MaxUses; 
                    replaceAbilityText2.text = GG.abilities[1].name + "   " + GG.abilities[1].uses + "/" + GG.abilities[1].MaxUses; 
                    replaceAbilityText3.text = GG.abilities[2].name + "   " + GG.abilities[2].uses + "/" + GG.abilities[2].MaxUses; 

                    replaceAbilityButton.SetActive(true);
                    added = true;
                    
                }
                }
            if (added == true)
            {
                break;
            }
            }
    }

    private void WinOrLoseCheck(int state) {

        //if health of the entity is lower than 0 switch state
        SwitchCounter = state;
        if (SIMP.Health < 0) {

            //Add death animation
            Skely.SetBool("IsDead", true);
            SwitchCounter = 4;
            
            Debug.Log("Won 11");
            
        }

        if (GG.Health < 0)
        {
            SkelyPlayer.SetBool("IsDead", true);
            SwitchCounter = 3;
            

            SIMP.Health = MaxEnemy;
        }

    }
    public void BacktoMain()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();

    }
    public void NextLevel(){

        SwitchCounter = 1;
        VictoryRoyal.SetActive(false);
        
        GenerateNextEnemy();
        MaxPlayer += sHealth;
        GG.Health = MaxPlayer;
        Skely.SetBool("IsDead", false);
        
    }
    public void ReplaceAbility(int i)
    {
        newAbility.uses = newAbility.MaxUses;
        GG.SetAbilities(newAbility, i);
        if(i == 0)
        {
            Ability1.text = newAbility.name;
            NextLevel();
        }
        else if(i == 1)
        {
            Ability2.text = newAbility.name;
            NextLevel();
        }
        else
        {
            Ability3.text = newAbility.name;
            NextLevel();
        }
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2f);
        UI.SetActive(true);
        PopupHeroText.SetActive(true);
    }


 

    public void SetAbilityInfoActive(int abilityPosition)
    {
        
        //AUI
        AbHeal.SetText("Heal: " + GG.abilities[abilityPosition].heal+"%");
        AbDamage.SetText("Damage: " + GG.abilities[abilityPosition].damage);
        AbType.SetText("Type: " + GG.abilities[abilityPosition].type);
        AbAccuracy.SetText("Accuracy: " + GG.abilities[abilityPosition].SuccessRate + "% + " + sAccuracy + "%");
        AbilityInfoUI.SetActive(true);
    }

    public void SetAbilityInfoInactive()
    {
        AbilityInfoUI.SetActive(false);
    }
    //Highscore setter
    public void SetHighscore(int level)
    {
        PlayerPrefs.SetInt("highscore", level);
    }
    //Highscore getter
    public int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public void addPotions()
    {
        int percentage = Random.Range(0, 101);
        Debug.Log("Percentage: " + percentage + " total luck: " + sLuck);
        if (percentage >= 0 && percentage <= 10+ sLuck)
        {
            potion1Uses++;
            
            APotion.SetText("Level 1 health potion received");
        }
        else if (percentage > 10 + sLuck && percentage <= 18 + (sLuck*2))
        {
            potion2Uses++;
            APotion.SetText("Level 2 health potion received");
        }
        else if (percentage > 18 + (sLuck*2) && percentage <= 24 + (sLuck*3))
        {
            potion3Uses++;
            APotion.SetText("Level 3 health potion received");
        }
        else if (percentage > 24 + (sLuck*3) && percentage <= 33 + (sLuck*4))
        {
            potion4Uses++;
            APotion.SetText("Uses refill received");
        }
        else
            APotion.SetText("No potion was received");
        potion1text.text = "" + potion1Uses;
        potion2text.text = "" + potion2Uses;
        potion3text.text = "" + potion3Uses;
        potion4text.text = "" + potion4Uses;
    }
    //Skill Tree adjustments
    public void sDamageSkill()
    {
        GG.Attack += 15;
        SkillTreeInfo.text = "+15 Attack. Total: " + GG.Attack;
    }
    public void sDefenseSkill()
    {
        GG.Defense += 10;
        SkillTreeInfo.text = "+10 Defense. Total: " + GG.Defense;
    }
    public void sHealthSkill()
    {
        sHealth += 50;
        SkillTreeInfo.text = "+50 Max HP.";
    }
    public void sDodgeSkill()
    {
        sDodge += 5;
        SkillTreeInfo.text = "+5% Dodge Chance. Total: "+sDodge+"%";
    }
    public void sLuckSkill()
    {
        sLuck += 3;
        SkillTreeInfo.text = "+3% Luck. Total: +"+sLuck+"%";
    }
    public void sCriticalChanceSkill()
    {
        sCriticalChance += 3;
        SkillTreeInfo.text = "+3% Critical Chance. Total: +" + sCriticalChance + "%";
    }
    public void sCriticalDamageSkill()
    {
        sCriticalDamage += 5;
        SkillTreeInfo.text = "+5% Critical Damage. Total: +" + sCriticalDamage + "%";
    }
    public void sAccuracySkill()
    {
        sAccuracy += 5;
        SkillTreeInfo.text = "+5% Accuracy. Total: +" + sAccuracy + "%";
    }
    public void sUseRefillSkill()
    {
        sUseRefill += 1;
        SkillTreeInfo.text = "You will refill for "+ sUseRefill+" all current abilities each level.";
    }




    void Start()
    {
        settings = controller.GetComponent<Settings>();
        skillTree = controller.GetComponent<SkillTree>();

        PopupHeroAnimation = PopupHeroHealText.GetComponent<Animator>();
    
        FloatingTxt = FloatingText.GetComponent<Animator>();

        PopupHeroTxt = PopupHeroText.GetComponent<Animator>();

        Skely = ObjrctSkely.GetComponent<Animator>();

        SkelyPlayer = Player.GetComponent<Animator>();

        BossAnimator = Boss.GetComponent<Animator>();

        mTitle.SetText(Level.ToString());

        GenerateAbilities();
        GenerateStats();
        GenerateEnemyStats();
        potion1text.text = "" + potion1Uses;
        potion2text.text = "" + potion2Uses;
        potion3text.text = "" + potion3Uses;
        potion4text.text = "" + potion4Uses;

        UI.SetActive(true);

    }

    void Update()
    {
        
        UpdateUI(SIMP, GG);
        switch (SwitchCounter)
        {

            case 1:
                //GG trurn
                break;

            case 2:
                //simp turn
                UI.SetActive(false);
                EnemyAttacking();
                

                break;


            case 3:
                //lose
                StopAllCoroutines();
                if (GetHighscore() < Level)
                    SetHighscore(Level);
                DefeatUI.SetActive(true);
                PopupHeroText.SetActive(false);
                UI.SetActive(false);
                break;


            case 4:

                //win
                AddStats();
                Debug.Log("Won");
                PopupHeroText.SetActive(false);
                UI.SetActive(false);
                addPotions();
                VictoryRoyal.SetActive(true);
                SwitchCounter = 5;
                StopAllCoroutines();

                break;


            case 5:
                StopAllCoroutines();
                break;

            case 6:
                //does nothing
                break;


        }
        
    }



   
}

