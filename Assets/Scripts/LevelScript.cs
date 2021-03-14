
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class LevelScript : MonoBehaviour
{

    public GameObject UI;

    public GameObject DefeatUI;


    public TextMeshPro EnemyHealth;
    public TextMeshPro EnemyType;

    //UI
    public TextMeshProUGUI mHealth;
    public TextMeshProUGUI mAttack;
    public TextMeshProUGUI mDefense;
    private string[] Type = { "Water", "Grass", "Fire" };

    //Level
    public TextMeshProUGUI mTitle;

    //UI 
    public TextMeshProUGUI LmLevel;
    public TextMeshProUGUI LmHealth;
    public TextMeshProUGUI LmAttack;
    public TextMeshProUGUI LmDefense;

<<<<<<< Updated upstream
    //max stats
    private int MaxPalyer;
=======
    private int MaxPlayer;
>>>>>>> Stashed changes
    private int MaxEnemy;

    private int Level = 1;

    //for switch
    private int SwitchCounter = 1;

    //GG stands 4 GamerGirl
    private Entity GG;
    
    //Enemy
    private Entity SIMP;

    private Abilities[3] abilities;

    
<<<<<<< Updated upstream

    private void UpdateUI(Entity SIMP, Entity GG) {
=======
    private void GenerateAbilities()
    {
        abilities[0] = new Abilities(50, "Fire", 0, 10);
        abilities[1] = new Abilities(40, "Water", 0, 15);
        abilities[2] = new Abilities(25, "Grass", 50, 10);
    }
>>>>>>> Stashed changes


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
        LmHealth.SetText("Health: " + MaxPalyer);
        LmAttack.SetText("Attack: " + GG.Attack); ;
        LmDefense.SetText("Defense: " + GG.Defense); ;




<<<<<<< Updated upstream

     }

    public void Attack()
=======
    public void AttackSlot1()
>>>>>>> Stashed changes
    {

        Debug.Log("test");

        Attacking(GG.abilities[1]);
    }
    public void AttackSlot2()
    {

        Debug.Log("test");

        Attacking(GG.abilities[2]);
    }
    public void AttackSlot3()
    {

        Debug.Log("test");

        Attacking(GG.abilities[3]);
    }

    private void Attacking(Abilities ability) {

        if (SIMP.Type == ability.type)
        {
            SIMP.EntityIsHit(1, ability);
        }
        else
        {
            SIMP.EntityIsHit(2, ability);
        }
        SwitchCounter = 2;


    }

<<<<<<< Updated upstream
    private int Simp(string type) {
          
        switch (SIMP.Type)
=======
    private int Simp(int damageType, Abilities ability) {
       
        switch (damageType)
>>>>>>> Stashed changes
        {
            //Immunity
            case 1:

                return 0;

            //Deals Damage
            case 2:
                //If ability heals
                if(ability.heal > 0)
                {
                    if(GG.Health < MaxPlayer)
                    {
                        GG.Health += ability.heal;
                        //checks if you overhealed so it sets your Health to your max Health instead
                        if(GG.Health > MaxPlayer) 
                        {
                            GG.Health = MaxPlayer;
                        }
                    }
                }
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
        int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
        int H = Random.Range(300, 401);


        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].type == TypeMe)
            {
                GG = new Entity(H, D, A, TypeMe, TypeMe[i]);
            }
            if (abilities[i].type == TypeEnemy)
            {
                SIMP = new Entity(H, D, A, TypeEnemy, TypeMe[i]);
            }
        }
        
        //set MaxHealth
        MaxPlayer = GG.Health;
        MaxEnemy = SIMP.Health;

    }
<<<<<<< Updated upstream

    //adds stats when 
=======
    //checks if new ability exists in players' inventory
    private bool ifExists(Abilities newAbility)
    {
        for (int i = 0; i < GG.abilities.length; i++)
        {
            if (GG.abilities[i].name == newAbility.name)
            {
                return true;
            }
        }
        return false;
    }

>>>>>>> Stashed changes
    private void AddStats() {

        Level++;


        GG.Attack += Random.Range(20, 31);
        GG.Defense += Random.Range(5, 11);
        GG.Health += Random.Range(70, 101);
        //give ability every time level is 2,4 or 6
        if (Level == 2 || Level == 4 || Level == 6)
        {
            //chooses random new ability
            
            for (int i = 0; i < abilities.Length; i++)
            {
                bool maxCapacity = true;
                Abilities newAbility = abilities[Random.Range(0, abilities.Length)];
                if (ifExists(newAbility) == false)
                {
                    for (int i = 0; i < GG.abilities.length; i++)
                    {
                        if (GG.abilities[i].name == null)
                        {
                            GG.abilities[i] = newAbility;
                            maxCapacity = false;
                        }
                    }
                    
                    if(maxCapacity == true)
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

    public void NextLevel() { 
    
    
    }

    void Start()
    {
<<<<<<< Updated upstream

        mTitle.SetText(Level.ToString());

=======
        GenerateAbilities();
>>>>>>> Stashed changes
        GenerateStats();
    }

    void Update()
    {

        UpdateUI(SIMP, GG);
        WinOrLoseCheck();

        switch (SwitchCounter) {

            case 1:
                //GG trurn

                UI.SetActive(true);

                break;

            case 2:
                //simp turn

<<<<<<< Updated upstream

                //change to false test
=======
              // change to false test
>>>>>>> Stashed changes
                UI.SetActive(false);

                break;

            case 3:
                //lose 

<<<<<<< Updated upstream

                DefeatUI.SetActive(true);
=======
>>>>>>> Stashed changes
                UI.SetActive(false);
                break;

            
            case 4:

                //win

                
                AddStats();
                UI.SetActive(false);
                break;



        }
    }
}
