
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    //animations 
    public GameObject FloatingText;
    public GameObject ObjrctSkely;
    public GameObject Player;

    private Animator Skely;
    private Animator SkelyPlayer;
    private Animator FloatingTxt;


  
    //All Abilities
    private Abilities[] abilities = { null, null, null, null, null,null };

    private Abilities EmptyAbility = new Abilities(0, " ", 0, 0, " ");

    private Abilities newAbility = new Abilities(0, " ", 0, 0, " ");

    private string[] Type = { "Water", "Grass", "Fire" };


    //max stats
    private int MaxPlayer;

    private int MaxEnemy;

    // gaind during lvl 
    private int GaindHealth = 0 ;

    private int GainAttack = 0 ;

    private int GainDefence = 0;

    private string TypeMe;

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
        abilities[2] = new Abilities(25, "Grass", 5, 10, "Grass blast");
        abilities[3] = new Abilities(10, "Fire", 0, 10, "Flame Wheel");
        abilities[4] = new Abilities(60, "Water", 15, 8, "Tsunami");
        abilities[5] = new Abilities(50, "Grass", 0, 10, "Branch slam");
    }



    private void UpdateUI(Entity SIMP, Entity GG) {
        //player
        mHealth.SetText(GG.Health + "/" + MaxPlayer);
        mDefense.SetText(""+GG.Defense);
        mAttack.SetText(""+GG.Attack);

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

    
        Attacking(GG.abilities[0]);

 
    }
    public void AttackSlot2()
    {
     

        Attacking(GG.abilities[1]);

      
    }
    public void AttackSlot3()
    {



        Attacking(GG.abilities[2]);

   
    }

    private void Attacking(Abilities ability)
    {
        //animations

        SkelyPlayer.SetTrigger("Attack");
        
        Skely.SetTrigger("IsDamage");

        int damage;

        if (SIMP.Type == ability.type)
        {
            Debug.Log(ability.damage);
            Debug.Log(SIMP.Health);

            damage = EntityIsHit(1, ability);

            EnemyGetDamage.SetText("-" + damage);
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);

            SIMP.Hit(damage);
        }
        else
        {

            damage = EntityIsHit(2, ability);

            EnemyGetDamage.SetText("-" + damage);
            FloatingTxt.Play("Base Layer.FloatingText", -1, 0f);

            SIMP.Hit(damage);

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


        //animations
        SkelyPlayer.SetTrigger("Damage");

        Skely.SetTrigger("IaAttack");
        


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
                // Add a pop up
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
        TypeMe = Type[Random.Range(0, Type.Length - 1)];
        int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
        int H = Random.Range(300, 401);
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].type == TypeMe)
            {
                
                GG = new Entity(H, D, A, TypeMe, abilities[i], EmptyAbility);
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
            if (abilities[i].type == TypeEnemy)
            {
                SIMP = new Entity(H, D, A, TypeEnemy, abilities[3], EmptyAbility);
            }
        }
        MaxEnemy = SIMP.Health;
    }

    private void AddStats() {

        Level++;
        mTitle.SetText(Level.ToString());

        GainAttack = Random.Range(20, 31);

        GainDefence = Random.Range(5, 11);

        GaindHealth = Random.Range(70, 101);

        GG.Health = MaxPlayer;

        GG.Attack += GainAttack;
        GG.Defense += GainDefence;
        GG.Health += GaindHealth;

        MaxPlayer = GG.Health;

            //chooses random new ability
            bool added = false;
            string maxCapacity = "No";
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
                        maxCapacity = "Yes";
                    }
                    
                
                if (maxCapacity == "Yes")
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
        GenerateEnemyStats();
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
        SwitchCounter = 1;
        
    }



    void Start()
    {

                FloatingTxt = FloatingText.GetComponent<Animator>();
                
                Skely = ObjrctSkely.GetComponent<Animator>();

                SkelyPlayer = Player.GetComponent<Animator>();


                 mTitle.SetText(Level.ToString());

                GenerateAbilities();

                GenerateStats();
                GenerateEnemyStats();

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
                Debug.Log("Won");
                UI.SetActive(false);
                VictoryRoyal.SetActive(true);
                SwitchCounter = 5;
                
                break;


            case 5:
                break;


        }
        
    }



   
}

