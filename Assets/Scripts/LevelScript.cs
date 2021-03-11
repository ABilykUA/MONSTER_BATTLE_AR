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



    //for switch
    private int SwitchCounter = 1;

    //GG stands 4 GamerGirl
    private Stats GG;

    //Enemy
    private Stats SIMP;


    //struct for stats pretty self explanatory  
    private struct Stats
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public string Type { get; set; }

        public Stats(int H, int D, int A,string T) {
            Attack = A;
            Defense = D;
            Health = H;
            Type = T;
        }

        public void hit(int value) {
            Health -= value;
        }
    }

   private void UpdateUI(Stats SIMP, Stats GG) {


        Debug.Log(SIMP.Health);

        //player
        mHealth.SetText("Health: " + GG.Health + "/" + MaxPalyer);
        mDefense.SetText("Defense: " + GG.Health);
        mAttack.SetText("Attack: " + GG.Attack); 

        //enely
        EnemyHealth.SetText("Health: " + SIMP.Health + "/" + MaxEnemy);
        EnemyType.SetText("Type: " + SIMP.Type);

    }


    //function for every attack 
    
    //Fire
    public void Attack()
    {
        

        switch(GG.Type){


            case "Water":


                SIMP.hit(Simp(GG.Type));

                SwitchCounter = 2;
                break;

            case "Grass":


                SIMP.hit(Simp(GG.Type));
                SwitchCounter = 2;
                
                
                break;

            case "Fire":

               


                SIMP.hit(Simp(GG.Type));

                
              

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

    void Start()
    {


         //GG stands 4 GamerGirl
        GG = new Stats(30, 45, 150, "Fire");

        //Enemy
        SIMP = new Stats(15, 80, 130, "Water");



        MaxPalyer = GG.Health;
        MaxEnemy = SIMP.Health;

     }



    void Update()
    {

        UpdateUI(SIMP, GG);


        switch (SwitchCounter) {

            case 1:



              
                UI.SetActive(true);

                break;

            case 2:



              
                UI.SetActive(false);

                break;


        }
    }
}
