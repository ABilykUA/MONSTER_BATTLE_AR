
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
    public GameObject RunOutUI;
    public GameObject SkillTreeTutorial;

    public GameObject VictoryRoyal;
    public GameObject VictoryWithTutorial;
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
    public TextMeshProUGUI AStun;
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
    public TextMeshProUGUI potion1info;
    public TextMeshProUGUI potion2info;
    public TextMeshProUGUI potion3info;


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
    private Abilities[] abilities = { null, null, null, null, null, null, null, null,null,null,null,null,null,null,null,null,null,null,null };

    private Abilities EmptyAbility = new Abilities(0, " ", 0, 0, " ", " ",0,"",0);

    private Abilities newAbility = new Abilities(0, " ", 0, 0, " ", " ",0,"",0);

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
    //Stun
    private bool sStun = false;
    private bool eStun = false;

    //enemyinfo
    public TextMeshProUGUI enemySpellInfo;
    public GameObject enemyInfoCanvas;
    public TextMeshProUGUI SkillTreeInfo;
    private int enemyAccuracy=0;
    SkillTree skillTree;

    //All the available abilities the user and enemy can get.
    private void GenerateAbilities()
    {
    
        abilities[0] = new Abilities(40, "Fire", 0, 15, "Fire bolt", "Grass",100,"A weak starting ability",0);
        abilities[1] = new Abilities(40, "Water", 0, 15, "Water gun", "Fire",100, "A weak starting ability",0);
        abilities[2] = new Abilities(40, "Grass", 0, 15, "Grass slap", "Water",100, "A weak starting ability",0);
        abilities[3] = new Abilities(50, "Fire", 0, 12, "Flame Wheel", "Grass",95,"",0);
        abilities[4] = new Abilities(65, "Water", 0, 10, "Tsunami", "Fire",80,"",0);
        abilities[5] = new Abilities(75, "Grass", 0, 8, "Branch slam", "Water",85,"",0);
        abilities[6] = new Abilities(0, "Grass", 30, 6, "Synthesis", "Water",100, "This ability heals and has 40% chance to stun.",40);
        abilities[7] = new Abilities(50, "Fire", 5, 10, "Flare Blitz", "Grass",95, "",0);
        abilities[8] = new Abilities(50, "Grass", 5, 10, "Solar Beam", "Water",95, "",0);
        abilities[9] = new Abilities(80, "Water", 5, 6, "Wave Force", "Fire",70, "",0);
        abilities[10] = new Abilities(65, "Chameleon", 0, 8, "Chameleon Whip", "Fire",85,"Adjusts to always counter the enemy type.",0);
        abilities[11] = new Abilities(50, "Chameleon", 10,6, "Chameleon Glare", "Fire", 80, "Adjusts to always counter the enemy type. Also heals.",0);
        abilities[12] = new Abilities(200, "Water", 0, 3, "Poseidon's Fury", "Fire", 30, "A high damage low accuracy ability made for performing miracles.",0);
        abilities[13] = new Abilities(70, "Fire", 10, 8, "Implosion", "Grass", 50, "The enemy violently implodes inwards dealing huge fire damage.",0);
        abilities[14] = new Abilities(75, "Water", 0, 8, "Moonchild Slam", "Fire", 70, "Blessed by an ability from the stars. 10% chance to stun.",10);
        abilities[15] = new Abilities(50, "Grass", 15, 10, "Amazons Wrath", "Water", 70, "Call the Amazons to your rescue.",0);
        abilities[16] = new Abilities(40, "Grass", 0, 7, "Root", "Water", 80, "Has a 30% chance to stun the enemy.", 30);
        abilities[17] = new Abilities(50, "Fire", 5, 7, "Flame Chains", "Grass", 80, "Has a 20% chance to stun the enemy.", 20);
        abilities[18] = new Abilities(50, "Water", 10, 7, "Bubble", "Fire", 80, "Has a 15% chance to stun the enemy.", 15);
    }

    //Color blind support. Changes the colors to fit a specific color blind type.
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
        {//Reset to the default colors if the user chooses 'None'
            
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


    //Updating every frame the UI.
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
        AUses.SetText("Uses: " + newAbility.MaxUses);
        AHeal.SetText("Heal: " + newAbility.heal+"%");
        AAccuracy.SetText("Accuracy: "+newAbility.SuccessRate);
        
        ADescription.SetText(newAbility.description);

        
       

    }

    //Health packs and use refill function. Heal for a % of your max health.
    public void HealthPotions(int potionType)
    {
        //Balance this!
        switch (potionType)
        {
            case 1:
                if (potion1Uses > 0)
                {

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" +  (int)(MaxPlayer * (25.0 / 100.0)));
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                  
                    if (MaxPlayer >= GG.Health+(MaxPlayer * (25.0/100.0)))
                    {
                        GG.Health += (MaxPlayer * (25.0 / 100.0));
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

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + (int)(MaxPlayer * (35.0 / 100.0)));
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                
                    if (MaxPlayer >= GG.Health+(MaxPlayer * (35.0 / 100.0)))
                    {
                        GG.Health += (MaxPlayer * (35.0 / 100.0));
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

                    PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("+" + (int)(MaxPlayer * (45.0 / 100.0)));
                    PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
                

                    if (MaxPlayer >= (GG.Health +(MaxPlayer * (45.0 / 100.0))))
                    {
                        GG.Health +=  (MaxPlayer * (45.0 / 100.0));
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

    //Click function for slot 1
    public void AttackSlot1()
    {
        PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
        PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
        Attacking(GG.abilities[0]);
        if (GG.abilities[0].uses > 0)
            GG.abilities[0].uses -= 1;
    }
    //Click function for slot 2
    public void AttackSlot2()
    {
        PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
        PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
        Attacking(GG.abilities[1]);
        if (GG.abilities[1].uses > 0)
            GG.abilities[1].uses -= 1;
    }
    //Click function for slot 3
    public void AttackSlot3()
    {
       PopupHeroHealText.GetComponent<TextMeshProUGUI>().SetText("");
       PopupHeroAnimation.Play("Base Layer.Heathpopup", -1, 0f);
       Attacking(GG.abilities[2]);
       if(GG.abilities[2].uses > 0)
            GG.abilities[2].uses -= 1;
            
        
    }
    //Whenever the player attacks call this function
    private void Attacking(Abilities ability)
    {
        //animations
        SkelyPlayer.SetTrigger("Attack");
        
        double heal;
        double damage=0;
        double crit = 1;
        int runOut = 0;
        int HitOrMiss = Random.Range(0, 101);
        for (int i= 0; i < GG.abilities.Length; i++)
        {
            if (GG.abilities[i].uses == 0)
                runOut++;
        }
        if (runOut == 3)
        {
            GG.Health -= MaxPlayer * (10 / 100);
            RunOutUI.SetActive(true);
        }
        if (!eStun)//Check if the player is stunned
        {
            if (ability.uses <= 0)//Check if you run out of uses.
            {

                damage = EntityIsHit(3, ability, SIMP.Type, SIMP.Counter, SIMP.Defense, GG.Attack, ref crit, true);

                //Change the UI text in case the player crits to inform them.
                if (crit >= 1.5 && crit < 2.0)
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

                if (HitOrMiss <= ability.SuccessRate + sAccuracy)//Check if an attack missed based on accuracy of ability and accuracy the player has.
                {
                    damage = EntityIsHit(1, ability, SIMP.Type, SIMP.Counter, SIMP.Defense, GG.Attack, ref crit, true);

                    if (crit >= 1.5 && crit < 2.0)
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
                }
                else
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
                if (HitOrMiss <= ability.SuccessRate + sAccuracy)//Check if an attack missed based on accuracy of ability and accuracy the player has.
                {
                    damage = EntityIsHit(2, ability, SIMP.Type, SIMP.Counter, SIMP.Defense, GG.Attack, ref crit, true);


                    if (crit >= 1.5 && crit < 2.0)
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
                }
                else
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
        }
        else//If the player is stunned don't allow them to use get the effect of the ability.
        {
            EnemyGetDamage.SetText("You are stunned!");
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
            eStun = false;
        }

        WinOrLoseCheck(2);

    }

    //Call this function whenever the enemy attacks
    private void EnemyAttacking()
    {
        //Trigger animations
        Skely.SetTrigger("IsDamage");

        BossAnimator.SetTrigger("BossTrigger");
        
        Abilities temp;
        //Enemy can use up to 3 abilities after level 3
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
        enemyInfoCanvas.SetActive(true);
        enemySpellInfo.SetText("Enemy used " + temp.name + ".");
        StartCoroutine(ExampleCoroutine());

        double damage=0;

        double crit = 1;
        int HitOrMiss = Random.Range(0, 101);
        Debug.Log("Enemy Ability name: " + temp.name);
        if (!sStun)
        {
            if (GG.Type == temp.type)
            {

                int percentForDodge = Random.Range(0, 101);
                if (percentForDodge <= sDodge&&sDodge>0)
                {
                    HeroGetDamage.SetText("Attack Dodged!");
                }
                else
                {
                    if (HitOrMiss <= temp.SuccessRate+enemyAccuracy)//Chance for the enemy to miss
                    {
                        //Play animations according to the specific type of hit. Crit, mega crit or normal.
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
                //A chance for the player to dodge 
                if (percentForDodge <= sDodge && sDodge > 0)
                {
                    HeroGetDamage.SetText("Attack Dodged!");
                }
                else
                {
                    if (HitOrMiss <= temp.SuccessRate+ enemyAccuracy)
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
                    SIMP.Health += ((MaxEnemy * (temp.heal-5)) / 100);
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (SIMP.Health > MaxEnemy)
                    {
                        SIMP.Health = MaxEnemy;
                    }

                }
            }
        }
        else
        {
            HeroGetDamage.SetText("Enemy is stunned!");
            sStun = false;
        }

        
        StopCoroutine(ExampleCoroutine());

        WinOrLoseCheck(1);
    }
 
    private double EntityIsHit(int damageType, Abilities ability, string targetType,string targetCounter, int def, int charAttack,ref double crit,bool player) 
    {
        double PlusMinus = Random.Range(-5, 5);
        double modifier = (100.0 / (100.0 + def));
        int randomizer = Random.Range(0, 101);
        int stunChance = Random.Range(0, 101);
        if (ability.stun>0&& stunChance <= ability.stun && player)
        {
            sStun = true;
        }else if (ability.stun > 0 && stunChance <= ability.stun && !player)
            eStun = true;

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
        
		int A = Random.Range(30, 41);
        int D = Random.Range(20, 31);
        int H = Random.Range(110, 131);
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
    //Generate initial enemy stats
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
		
        int A = Random.Range(25, 33);
        int D = Random.Range(15, 26);
        int H = Random.Range(90, 111);

        

        for (int i = 0; i < 3; i++)
        {
            if (abilities[i].type == TypeEnemy && abilities[i].damage != 0)
            {
                SIMP = new Entity(H, D, A, TypeEnemy, counterType, abilities[i], EmptyAbility);
            }
        }
		
        MaxEnemy = SIMP.Health;
    }
    //Scaling enemy stats every level
    private void GenerateNextEnemy()
    {
        Abilities tempA;
        string TypeEnemy = Type[Random.Range(0, Type.Length)];
        //boss fight every 5 levels
        int A, D, H;
        if (Level % 5 == 0)//Every 5 levels you get a boss battle that has your stats that are slightly stronger than you.
        {
            Boss.SetActive(true);
            Skelly.SetActive(false);
            A = GG.Attack+ (int)(GG.Attack * (5.0 / 100.0));
            D = GG.Defense;
            H = (int)(GG.Health + (GG.Health*(20.0/100.0)));
            MaxBoss = (int)(GG.Health + (GG.Health * (20.0 / 100.0)));

        }
        else
        {
            Boss.SetActive(false);
            Skelly.SetActive(true);

            GainAttack = Random.Range(15, 21);

            GainDefence = Random.Range(13, 18);

            GaindHealth = Random.Range(50, 57);

            SIMP.Health = MaxEnemy;
            A = SIMP.Attack + GainAttack;
            D = SIMP.Defense + GainDefence;
            H = (int)(SIMP.Health + GaindHealth);
            MaxEnemy = SIMP.Health + GaindHealth;
            
        }
        //Every 11 levels the enemy gets additional stats.
        if(Level % 11 == 0)
        {
            A += 15;
            D += 10;

        }

        //find the coutner type of an enemy.
        string counterType;
        if (TypeEnemy == "Fire")
            counterType = "Water";
        else if (TypeEnemy == "Water")
            counterType = "Grass";
        else if (TypeEnemy == "Grass")
            counterType = "Fire";
        else
            counterType = "";

        //Every 4 levels increase the enemies accuracy by 3.
        if (Level % 4 == 0)
            enemyAccuracy += 3;

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
                if (tempA.type == TypeEnemy && tempA.damage != 0)//Give the enemy an ability that is his type 
                {
                    SIMP = new Entity(H, D, A, TypeEnemy, counterType, abilities[i], EmptyAbility);
                    break;
                }
            }
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[Random.Range(0,abilities.Length)];
                if (tempA.type == TypeEnemy && tempA.damage != 0 && SIMP.GetAbilities(0).name != tempA.name)
                {
                    SIMP.SetAbilities(tempA, 1);
                    break;
                }
            }
            for (int i = 0; i < abilities.Length; i++)
            {
                tempA = abilities[Random.Range(0, abilities.Length)];
                if (tempA.type == TypeEnemy && tempA.damage != 0 && SIMP.GetAbilities(0).name != tempA.name && SIMP.GetAbilities(1).name != tempA.name)
                {
                    SIMP.SetAbilities(tempA, 2);
                    break;
                }
            }
            
            
        }
    }
    //Add stats to the player every level
    private void AddStats() {

        //If you defeat a boss you get 2 instead of 1 skill points.
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
        GainAttack = Random.Range(15, 26);

        GainDefence = Random.Range(10, 15);

        GaindHealth = Random.Range(60, 71);

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
                    //If you have 3 abilities give the option to replace them.
             
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
    //Checks every round if you or the enemy die.
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
    //Go back to the main menu
    public void BacktoMain()
    {
        SceneManager.LoadScene(0);
    }
    //Exit the game completely. Close the app
    public void ExitGame()
    {
        Application.Quit();

    }
    //Proceed to the next level.
    public void NextLevel(){

        SwitchCounter = 1;
        VictoryRoyal.SetActive(false);
        VictoryWithTutorial.SetActive(false);


        GenerateNextEnemy();
        MaxPlayer += sHealth;
        GG.Health = MaxPlayer;
        Skely.SetBool("IsDead", false);
        
    }
    //Replace an ability you currently have with a brand new one.
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
    //Wait for animations to finish and then do something.
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2f);
        UI.SetActive(true);
        PopupHeroText.SetActive(true);
        enemySpellInfo.SetText("");
        enemyInfoCanvas.SetActive(false);
        RunOutUI.SetActive(false);
    }
    
    //Initialize the ability info of one of the 3 abilities you currently have.
    public void SetAbilityInfoActive(int abilityPosition)
    {
        
        //AUI
        AbHeal.SetText("Heal: " + GG.abilities[abilityPosition].heal+"%");
        AbDamage.SetText("Damage: " + GG.abilities[abilityPosition].damage);
        AbType.SetText("Type: " + GG.abilities[abilityPosition].type);
        AbAccuracy.SetText("Accuracy: " + GG.abilities[abilityPosition].SuccessRate + "% + " + sAccuracy + "%");
        AStun.SetText("Stun: " + GG.abilities[abilityPosition].stun + "%");
        AbilityInfoUI.SetActive(true);
    }
    //Disable the info UI when the player presses the close button on AbilityInfoUI
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
    //Earn potions randomly each level you win.
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
    //Buff damage skill
    public void sDamageSkill()
    {
        GG.Attack += 5;
        SkillTreeInfo.text = "+5 Attack. Total: " + GG.Attack;
    }
    //Buff defense skill
    public void sDefenseSkill()
    {
        GG.Defense += 5;
        SkillTreeInfo.text = "+5 Defense. Total: " + GG.Defense;
    }
    //Buff max health 
    public void sHealthSkill()
    {
        sHealth += 50;
        SkillTreeInfo.text = "+" + sHealth + " Max HP.";
    }
    //Buff dodge percentage 
    public void sDodgeSkill()
    {
        sDodge += 5;
        SkillTreeInfo.text = "+5% Dodge Chance. Total: "+sDodge+"%";
    }
    //Buff luck percentage
    public void sLuckSkill()
    {
        sLuck += 3;
        SkillTreeInfo.text = "+3% Luck. Total: +"+sLuck+"%";
    }
    //Buff critical chance percentage
    public void sCriticalChanceSkill()
    {
        sCriticalChance += 3;
        SkillTreeInfo.text = "+3% Critical Chance. Total: +" + sCriticalChance + "%";
    }
    //Buff critical damage dealt
    public void sCriticalDamageSkill()
    {
        sCriticalDamage += 5;
        SkillTreeInfo.text = "+5% Critical Damage. Total: +" + sCriticalDamage + "%";
    }
    //Buff the accuracy. (Player misses attacks less)
    public void sAccuracySkill()
    {
        sAccuracy += 5;
        SkillTreeInfo.text = "+5% Accuracy. Total: +" + sAccuracy + "%";
    }
    //Earn refill of ability uses every round.
    public void sUseRefillSkill()
    {
        sUseRefill += 1;
        SkillTreeInfo.text = "You will refill for "+ sUseRefill+" all current abilities each level.";
    }

    //Disable tutorials after they are first seen.
    public void TutorialDisable(int index)
    {
        switch (index)
        {
            case 1:
                PlayerPrefs.SetInt("SkillTreeButtonT", 1);
                break;

        }
    }

    void Start()
    {
        //Check if the player has seen the tutorial before.
        if (PlayerPrefs.GetInt("SkillTreeButtonT", 0) == 0)
            SkillTreeTutorial.SetActive(true);


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
    //Update potion UI to represent the amount they are going to heal the player. (Visual aid for more strategical plays)
    private void UpdatePotions()
    {
        potion1info.text = "+"+ (int)(MaxPlayer * (25.0 / 100.0));
        potion2info.text = "+" + (int)(MaxPlayer * (35.0 / 100.0));
        potion3info.text = "+" + (int)(MaxPlayer * (45.0 / 100.0));
    }

    void Update()
    {
        UpdatePotions();
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
                enemyInfoCanvas.SetActive(false);
                RunOutUI.SetActive(false);
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
                VictoryWithTutorial.SetActive(true);
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

