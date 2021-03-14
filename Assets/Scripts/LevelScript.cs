using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelScript : MonoBehaviour
{

    public GameObject UI;


    public TextMeshPro EnemyHealth;
    public TextMeshPro EnemyType;


    public TextMeshProUGUI mHealth;
    public TextMeshProUGUI mAttack;
    public TextMeshProUGUI mDefense;


    private int MaxPalyer;
    private int MaxEnemy;

    private int Level = 1;

    //for switch
    private int SwitchCounter = 1;

    //GG stands 4 GamerGirl
    private Entity GG;
    
    //Enemy
    private Entity SIMP;


    

   private void UpdateUI(Entity SIMP, Entity GG) {



        //player
        mHealth.SetText("Health: " + GG.Health + "/" + MaxPalyer);
        mDefense.SetText("Defense: " + GG.Defense);
        mAttack.SetText("Attack: " + GG.Attack); 

        //enely
        EnemyHealth.SetText("Health: " + SIMP.Health + "/" + MaxEnemy);
        EnemyType.SetText("Type: " + SIMP.Type);

    }


    public void Attack()
    {

        Debug.Log("test");


        Player();
    }

    private void Player() {


        switch (GG.Type)
        {


            case "Water":




                SIMP.EntityISHit(Simp(GG.Type));
                SwitchCounter = 2;
                break;

            case "Grass":





                SIMP.EntityISHit(Simp(GG.Type));
                SwitchCounter = 2;
                break;

            case "Fire":






                SIMP.EntityISHit(Simp(GG.Type));
                SwitchCounter = 2;
                break;



        }



    }

    private int Simp(string type) {
       
        switch (SIMP.Type)
        {
            case "Water":

                if (type == "Water") {

                    return 30;

                } else if (type == "Grass") {

                    return 50;

                }
                else {

                    return 80;
                
                }

              

            case "Grass":

                if (type == "Water")
                {

                    return 30;

                }
                else if (type == "Grass")
                {

                    return 50;

                }
                else
                {

                    return 80;

                }



            case "Fire":
                
                if (type == "Water")
                {

                    return 30;

                }
                else if (type == "Grass")
                {

                    return 50;

                }
                else
                {

                    return 80;

                }




            default:
                
                return 0;
                
               
        }
        
    }

    private void GenerateStats() {


        string[] Type = {"Water","Grass","Fire"};

        int A = Random.Range(50, 71);
        int D = Random.Range(20, 41);
        int H = Random.Range(300, 401);

        GG = new Entity(H, D, A, Type[Random.Range(0, Type.Length)]);
        
        SIMP = new Entity(H, D, A, Type[Random.Range(0,Type.Length)]);

        //set MaxHealth
        MaxPalyer = GG.Health;
        MaxEnemy = SIMP.Health;

    }


    private void AddStats() {

        Level++;

        GG.Attack += Random.Range(20, 31);
        GG.Defense += Random.Range(5, 11);
        GG.Health += Random.Range(70, 101);

        
    }
    
    private void WinCheck() {

        if (SIMP.Health <= 0) {
            SwitchCounter = 4;
        }
    
    }


    void Start()
    {

        GenerateStats();
    
    }

    void Update()
    {

        UpdateUI(SIMP, GG);
        WinCheck();


        switch (SwitchCounter) {

            case 1:
                //GG trurn


              
                UI.SetActive(true);

                break;

            case 2:
                //simp turn


              // change to false test
                UI.SetActive(false);

                break;



            case 3:
                //lose 



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
