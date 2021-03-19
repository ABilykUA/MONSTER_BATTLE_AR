
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class LevelScript : MonoBehaviour
{
    public GameObject UI;

    public GameObject DefeatUI;
    public Abilities newAbility;


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

    //All Abilities
    private Abilities[] abilities = { null, null, null };

    //max stats
    private int MaxPlayer;

    private int MaxEnemy;

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

        private void Attacking(Abilities ability) {

            if (SIMP.Type == ability.type)
            {
                SIMP.Hit(EntityIsHit(1, ability));
            }
            else
            {
                SIMP.Hit(EntityIsHit(2, ability));
            }
            SwitchCounter = 2;


        }



    private int EntityIsHit(int damageType, Abilities ability) {

                switch (damageType)

                {
                    //Immunity
                    case 1:

                        return 0;

                    //Deals Damage
                    case 2:
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
                        GG= new Entity(H, D, A, TypeMe, abilities[i]);
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


            private void Start()
            {
            
                mTitle.SetText(Level.ToString());

                GenerateAbilities();

                GenerateStats();
            }




    void Update()
    {

        UpdateUI(SIMP, GG);
        WinOrLoseCheck();

        switch (SwitchCounter)
        {

            case 1:
                //GG trurn

                UI.SetActive(true);

                break;

            case 2:
                //simp turn

                //change to false test

                UI.SetActive(false);

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
                break;



        }
    }
}

