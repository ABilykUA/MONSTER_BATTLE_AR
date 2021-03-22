
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LevelScript : MonoBehaviour
{
    public GameObject UI;

    public GameObject VictoryRoyal;
    public GameObject SettingsScreen;

    public GameObject DefeatUI;

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

    //WinUIAbilitys
    public TextMeshProUGUI AHeal;
    public TextMeshProUGUI ADamage;
    public TextMeshProUGUI AType;
    public TextMeshProUGUI AName;
    public TextMeshProUGUI AUses;




    //All Abilities
    private Abilities[] abilities = { null, null, null };

    private Abilities newAbility = new Abilities(0, " ", 0, 0, " ");

    private string[] Type = { "Water", "Grass", "Fire" };


    //max stats
    private int MaxPlayer;

    private int MaxEnemy;

    // gaind during lvl 
    private int GaindHealth = 0 ;

    private int GainAttack = 0 ;

    private int GainDefence = 0;



    private int Level = 1;

    //for switch
    private int SwitchCounter = 1;

    //GG stands 4 GamerGirl
    private Entity GG;

    //Enemy
    private Entity SIMP;



    private void GenerateAbilities()
    {
        abilities[0] = new Abilities(50, "Fire", 0, 10, "Fire blast");
        abilities[1] = new Abilities(40, "Water", 0, 15, "Water blast");
        abilities[2] = new Abilities(25, "Grass", 50, 10, "Grass blast");
        abilities[2] = new Abilities(25, "Grass", 10, 10, "Grass blast");
        abilities[3] = new Abilities(20, "Fire", 5, 10, "Flame Wheel");
        abilities[4] = new Abilities(60, "Water", 15, 8, "Tsunami");
        abilities[5] = new Abilities(50, "Grass", 0, 10, "Branch slam");
    }



    private void UpdateUI(Entity SIMP, Entity GG) {

        //player
        mHealth.SetText("Health: " + GG.Health + "/" + MaxPlayer);
        mDefense.SetText("Defense: " + GG.Defense);
        mAttack.SetText("Attack: " + GG.Attack);

        //enely
        EnemyHealth.SetText("Health: " + SIMP.Health + "/" + MaxEnemy);
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

        //newAbility


        ADamage.SetText("Damage: " + newAbility.damage);
        AType.SetText("Type: " + newAbility.type);
        AName.SetText("Name: " + newAbility.name);
        AUses.SetText("Uses: " + newAbility.uses);
        AHeal.SetText("Heal: " + newAbility.heal);

    }

    public void AttackSlot1()
    {

        Debug.Log("test");

        Attacking(GG.abilities[0]);
    }
    public void AttackSlot2()
    {
        Debug.Log("test");

        Attacking(GG.abilities[1]);
    }
    public void AttackSlot3()
    {

        Debug.Log("test");

        Attacking(GG.abilities[2]);
    }

    private void Attacking(Abilities ability)
    {

        if (SIMP.Type == ability.type)
        {
            SIMP.Hit(EntityIsHit(1, ability));
        }
        else
        {
            SIMP.Hit(EntityIsHit(2, ability));

            //If ability heals
            if (ability.heal > 0)
            {
                if (GG.Health < MaxPlayer)
                {
                    GG.Health += ability.heal;
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
        Abilities temp = SIMP.GetAbilities(0);
        if (GG.Type == temp.type)
        {
            GG.Hit(EntityIsHit(1, temp));
        }
        else
        {
            GG.Hit(EntityIsHit(2, temp));
            //If ability heals
            if (temp.heal > 0)
            {
                if (SIMP.Health < MaxPlayer)
                {
                    SIMP.Health += temp.heal;
                    //checks if you overhealed so it sets your Health to your max Health instead
                    if (SIMP.Health > MaxPlayer)
                    {
                        SIMP.Health = MaxPlayer;
                    }
                }
            }
        }
        SwitchCounter = 1;

    }


    private int EntityIsHit(int damageType, Abilities ability) {

        switch (damageType)

        {
            //Immunity
            case 1:
                // Add a poo up
                return 0;

            //Deals Damage
            case 2:              
                return ability.damage;

            default:

                return 0;


        }
    }
    //generates stats on the first frame 
    private void GenerateStats() {
        //whatever type you get for enemy or you you get the same type of ability
        string TypeMe = Type[Random.Range(0, Type.Length)];
        string TypeEnemy = Type[Random.Range(0, Type.Length)];
        for (int i = 0; i < 6; i++)
        {
            if (TypeEnemy != TypeMe)
            {
                break;
            }
            else
            {
                TypeEnemy = Type[Random.Range(0, Type.Length)];
            }
        }
        int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
        int H = Random.Range(300, 401);


        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].type == TypeMe)
            {
                GG = new Entity(H, D, A, TypeMe, abilities[i]);
            }
            if (abilities[i].type == TypeEnemy)
            {
                SIMP = new Entity(H, D, A, TypeEnemy, abilities[i]);
            }
        }

        //set MaxHealth
        MaxPlayer = GG.Health;
        MaxEnemy = SIMP.Health;

    }
    //adds stats when 

    //checks if new ability exists in players' inventory
    private bool ifExists(Abilities newAbility)
    {
        for (int i = 0; i < GG.abilities.Length; i++)
        {
            if (GG.abilities[i].name == newAbility.name)
            {
                return true;
            }
        }
        return false;
    }
    private void AddStats() {

        Level++;

        GainAttack = Random.Range(20, 31);

        GainDefence = Random.Range(5, 11);

        GaindHealth = Random.Range(70, 101);


        GG.Attack += GainAttack;
        GG.Defense += GainDefence;
        GG.Health += GaindHealth;

        //give ability every time level is 2,4 or 6
        if (Level == 2 || Level == 4 || Level == 6)
        {
            //chooses random new ability

            for (int i = 0; i < abilities.Length; i++)
            {
                bool maxCapacity = true;
                newAbility = abilities[Random.Range(0, abilities.Length)];
                if (ifExists(newAbility) == false)
                {
                    for (int j = 0; j < GG.abilities.Length; j++)
                    {
                        if (GG.abilities[j].name == null)
                        {
                            GG.abilities[j] = newAbility;
                            maxCapacity = false;
                        }
                    }

                    if (maxCapacity == true)
                    {
                        //TODO needs to get the new window where the player chooses which ability to replace!!!
                        break;
                    }
                }

            }

        }

        mTitle.SetText(Level.ToString());
    }
    private void WinOrLoseCheck() {

        //if health of the entity is lower than 0 switch state

        if (SIMP.Health <= 0) {
            SwitchCounter = 4;
        }

        if (GG.Health <= 0)
        {
            SwitchCounter = 3;
        }

    }


    public void NextLevel(){}




    private void Start()
            {
            
                mTitle.SetText(Level.ToString());

                GenerateAbilities();

                GenerateStats();
            }

    void Update()
    {

        UpdateUI(SIMP, GG);
        

        switch (SwitchCounter)
        {

            case 1:
                //GG trurn
                WinOrLoseCheck();
                UI.SetActive(true);
                break;


            case 2:
                //simp turn
                WinOrLoseCheck();
                //change to false test

                UI.SetActive(false);
                EnemyAttacking();
                break;


            case 3:
                //lose 



                DefeatUI.SetActive(true);

                UI.SetActive(false);
                break;


            case 4:

                //win

               
                AddStats();
                UI.SetActive(false);
                VictoryRoyal.SetActive(true);
                SwitchCounter = 5;
                break;


            case 5:
                break;


        }
    }



   
}

