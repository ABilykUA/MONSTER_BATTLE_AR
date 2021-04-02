﻿
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

    //Level
    public TextMeshProUGUI mTitle;

    //Lose UI 
    public TextMeshProUGUI LmLevel;
    public TextMeshProUGUI LmHealth;
    public TextMeshProUGUI LmAttack;
    public TextMeshProUGUI LmDefense;

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

    public TextMeshPro EnemyGetDamage;
 
 
    public TextMeshProUGUI HeroGetDamage;


    //animations 
    public GameObject PopupHeroText;
    public GameObject FloatingText;


    public GameObject ObjrctSkely;
    public GameObject Player;

    
    private Animator Skely;
    private Animator SkelyPlayer;

    private Animator FloatingTxt;
    private Animator PopupHeroTxt;



    //All Abilities
    private Abilities[] abilities = { null, null, null, null, null, null, null, null,null,null };

    private Abilities EmptyAbility = new Abilities(0, " ", 0, 0, " ", " ");

    private Abilities newAbility = new Abilities(0, " ", 0, 0, " ", " ");

    private string[] Type = { "Water", "Grass", "Fire" };


    //max stats
    private double MaxPlayer;

    private double MaxEnemy;

    private int MaxUses1;
    private int MaxUses2;
    private int MaxUses3;

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




    private void GenerateAbilities()
    {
        abilities[0] = new Abilities(40, "Fire", 0, 15, "Fire bolt", "Grass");
        abilities[1] = new Abilities(40, "Water", 0, 15, "Water gun", "Fire");
        abilities[2] = new Abilities(35, "Grass", 0, 15, "Grass slap", "Water");
        abilities[3] = new Abilities(35, "Fire", 0, 10, "Flame Wheel", "Grass");
        abilities[4] = new Abilities(65, "Water", 0, 10, "Tsunami", "Fire");
        abilities[5] = new Abilities(50, "Grass", 0, 10, "Branch slam", "Water");
        abilities[6] = new Abilities(0, "Grass", 20, 5, "Synthesis", "Water");
        abilities[7] = new Abilities(50, "Fire", 5, 10, "Flare Blitz", "Grass");
        abilities[8] = new Abilities(50, "Grass", 5, 10, "Solar Beam", "Water");
        abilities[9] = new Abilities(80, "Water", 5, 5, "Wave Force", "Fire");
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


        //enely
        EnemyHealth.SetText("Health: " + (int)SIMP.Health + "/" + MaxEnemy);

        EnemyType.SetText("Type: " + SIMP.Type);

        //Level
        mTitle.SetText("Level: " + Level);

        //DUI 
        LmLevel.SetText("You made it to level: " + Level);
        LmHealth.SetText("Health: " + MaxPlayer);
        LmAttack.SetText("Attack: " + GG.Attack);
        LmDefense.SetText("Defense: " + GG.Defense);

        //WUI
        WHealth.SetText("Health: +" + GaindHealth);
        WAttack.SetText("Attack: +" + GainAttack);
        WDefense.SetText("Defense: +" + GainDefence);

        //Current Abilities
        Ability1.text = GG.abilities[0].name + "   " + GG.abilities[0].uses + "/" + MaxUses1;
        Ability2.text = GG.abilities[1].name + "   " + GG.abilities[1].uses + "/" + MaxUses2;
        Ability3.text = GG.abilities[2].name + "   " + GG.abilities[2].uses + "/" + MaxUses3;

        //newAbility


        ADamage.SetText("Damage: " + newAbility.damage);
        AType.SetText("Type: " + newAbility.type);
        AName.SetText("Name: " + newAbility.name);
        AUses.SetText("Uses: " + newAbility.uses);
        AHeal.SetText("Heal: " + newAbility.heal+"%");




    }

    public void AttackSlot1()
    {
        
        Attacking(GG.abilities[0]);
        if (GG.abilities[0].uses > 0)
            GG.abilities[0].uses -= 1;
    }
    public void AttackSlot2()
    {

        Attacking(GG.abilities[1]);
        if (GG.abilities[1].uses > 0)
            GG.abilities[1].uses -= 1;
    }
    public void AttackSlot3()
    {

        Attacking(GG.abilities[2]);
        if(GG.abilities[2].uses > 0)
            GG.abilities[2].uses -= 1;
            
        
    }

    private void Attacking(Abilities ability)
    {
        //animations
        SkelyPlayer.SetTrigger("Attack");

        
        double damage;
        if (ability.uses <= 0)
        {
            damage = EntityIsHit(3, ability, SIMP.Type, SIMP.Defense, GG.Attack);
            EnemyGetDamage.SetText("-" + (int)damage);
            FloatingTxt.Play("Base Layer.PopupHeroText", -1, 0f);
            SIMP.Hit(damage);
            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    double heal = (MaxPlayer * ability.heal) / 100;
                    GG.Health += heal;
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (GG.Health > MaxPlayer)
                    {
                        GG.Health = MaxPlayer;
                        //change color to green
                        EnemyGetDamage.SetText("+" + (int)heal);
                        FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
                    }
                }
            }
        }
        else if (ability.uses > 0 && SIMP.Type == ability.type)
        {
            

            damage = EntityIsHit(1, ability, SIMP.Type, SIMP.Defense, GG.Attack);
           
            EnemyGetDamage.SetText("-" + (int)damage);
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    double heal = (MaxPlayer * ability.heal) / 100;
                    GG.Health += heal;
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (GG.Health > MaxPlayer)
                    {
                        GG.Health = MaxPlayer;
                        //change color to green
                        EnemyGetDamage.SetText("+" + (int)heal);
                        FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);
                    }
                }
            }

            SIMP.Hit(damage);
        }
        else
        {
            
            damage = EntityIsHit(2, ability, SIMP.Type, SIMP.Defense, GG.Attack);
            
            EnemyGetDamage.SetText("-" + (int)damage);
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);

            SIMP.Hit(damage);

            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    GG.Health += ((MaxPlayer * ability.heal) / 100 );
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (GG.Health > MaxPlayer)
                    {
                        GG.Health = MaxPlayer;
                    }
                }
            }
        }


        SwitchCounter = 2;


    }

    private void EnemyAttacking()
    {
        Skely.SetTrigger("IsDamage");
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
        

        double damage;


        Debug.Log("Enemy Ability name: " + temp.name);
        if (GG.Type == temp.type)
        {
            damage = EntityIsHit(1, temp, GG.Type, GG.Defense, SIMP.Attack);
            HeroGetDamage.SetText("-" + (int)damage);
            PopupHeroTxt.Play("Base Layer.PopupHeroText", -1, 0f);
            GG.Hit(damage);

        }
        else
        {
            damage = EntityIsHit(2, temp, GG.Type, GG.Defense, SIMP.Attack);
            HeroGetDamage.SetText("-" + (int)damage);
            PopupHeroTxt.Play("Base Layer.PopupHeroText", -1, 0f);
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
        SwitchCounter = 1;

    }

    private double EntityIsHit(int damageType, Abilities ability, string targetType, int def, int charAttack) 
    {
        double PlusMinus = Random.Range(-5, 5);
        double modifier = (100.0 / (100.0 + def));
        int randomizer = Random.Range(0, 101);
        double crit = 1.0;
        if (randomizer <= 10)
        {
            crit = 2.0;
            Debug.Log("Crit!");
        }
        else if (randomizer > 10 && randomizer <= 13)
        {
            crit = 2.5;
            Debug.Log("MEGACrit!");
        }
        switch (damageType)

        {
            //Immunity
            case 1:
                // Add a pop up
                return ((((ability.damage + PlusMinus) * charAttack) / 100)) * crit;

            //Deals Damage
            case 2:
                if(ability.counter == targetType)
                {
                    return (((((ability.damage + PlusMinus) * charAttack) / 100) * modifier)*2)*crit;
                }
                else
                {
                    return ((((ability.damage + PlusMinus) * charAttack) / 100) * modifier)*crit;
                }

            case 3:

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
                MaxUses1 = abilities[i].uses;
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
		
        int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
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
        if (Level % 5 == 0)
        {
            Boss.SetActive(true);
            Skelly.SetActive(false);
        }
        else
        {
            Boss.SetActive(false);
            Skelly.SetActive(true);
        }

        GainAttack = Random.Range(10, 21);

        GainDefence = Random.Range(5, 11);

        GaindHealth = Random.Range(40, 71);
        string counterType;
        if (TypeEnemy == "Fire")
            counterType = "Water";
        else if (TypeEnemy == "Water")
            counterType = "Grass";
        else if (TypeEnemy == "Grass")
            counterType = "Fire";
        else
            counterType = "";

        SIMP.Health = MaxEnemy;
        int A = SIMP.Attack + GainAttack;
        int D = SIMP.Defense + GainDefence;
        int H = (int)(SIMP.Health + GaindHealth);

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
            MaxEnemy = SIMP.Health;
        }
    }
    private void AddStats() {

        Level++;
        mTitle.SetText(Level.ToString());

        GainAttack = Random.Range(10, 21);

        GainDefence = Random.Range(5, 11);

        GaindHealth = Random.Range(50, 81);

        GG.Health = MaxPlayer;

        GG.Attack += GainAttack;
        GG.Defense += GainDefence;
        GG.Health += GaindHealth;

        MaxPlayer = GG.Health;

            //chooses random new ability
            bool added = false;
            bool maxCapacity = false;
            for (int i = 0; i < abilities.Length; i++)
            {

            newAbility = abilities[Random.Range(0, abilities.Length - 1)];
            Debug.Log(newAbility.name);
                if (newAbility.name != GG.abilities[0].name 
                && newAbility.name != GG.abilities[1].name 
                && newAbility.name != GG.abilities[2].name)
                {
                Debug.Log("If exists");
                    if (GG.abilities[1].name == " ")
                    {
                        
                        GG.abilities[1] = newAbility;
                        Debug.Log("Activate new button 1");
                        Button2.SetActive(true);
                        GG.SetAbilities(newAbility, 1);
                        added = true;
                        Ability2.text = newAbility.name;
                        MaxUses2 = newAbility.uses;

                    }
                    else if (GG.abilities[2].name == " " && added != true)
                    {
                        Debug.Log("Activate new button 2");
                        Button3.SetActive(true);
                        GG.SetAbilities(newAbility, 2);
                        added = true;
                        Ability3.text = newAbility.name;
                        MaxUses3 = newAbility.uses;
                    }
                    else 
                    { 
                        maxCapacity = true;
                    }
                    
                
                if (maxCapacity)
                {
                    //TODO needs to get the new window where the player chooses which ability to replace!!!
                    replaceAbilityText1.text = GG.abilities[0].name;
                    replaceAbilityText2.text = GG.abilities[1].name;
                    replaceAbilityText3.text = GG.abilities[2].name;
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

    private void WinOrLoseCheck() {

        //if health of the entity is lower than 0 switch state

        if (SIMP.Health <= 0) {

            //Add death animation
            Skely.SetBool("IsDead", true);
            
            SwitchCounter = 4;
            Debug.Log("Won 11");
            
        }

        if (GG.Health <= 0)
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
        GG.Health = MaxPlayer;
        Skely.SetBool("IsDead", false);
        

    }
    public void ReplaceAbility(int i)
    {
        //replaceAbilityText1.text = GG.abilities[0].name;
        //replaceAbilityText2.text = GG.abilities[1].name;
        //replaceAbilityText3.text = GG.abilities[2].name;
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

    }



    void Start()
    {
        settings = controller.GetComponent<Settings>();

            
        FloatingTxt = FloatingText.GetComponent<Animator>();

        PopupHeroTxt = PopupHeroText.GetComponent<Animator>();

        Skely = ObjrctSkely.GetComponent<Animator>();

        SkelyPlayer = Player.GetComponent<Animator>();


        mTitle.SetText(Level.ToString());

        GenerateAbilities();

        GenerateStats();
        GenerateEnemyStats();


        UI.SetActive(true);

    }

    void Update()
    {

        UpdateUI(SIMP, GG);
        switch (SwitchCounter)
        {

            case 1:
                //GG trurn
                WinOrLoseCheck();
                break;


            case 2:
                //simp turn
                WinOrLoseCheck();
                UI.SetActive(false);
                EnemyAttacking();
                

                break;


            case 3:
                //lose
                StopAllCoroutines();

                DefeatUI.SetActive(true);
                UI.SetActive(false);
                break;


            case 4:

                //win
                AddStats();
                Debug.Log("Won");
                UI.SetActive(false);
                VictoryRoyal.SetActive(true);
                SwitchCounter = 5;
                StopAllCoroutines();

                break;


            case 5:
                StopAllCoroutines();
                break;


        }
        
    }



   
}

