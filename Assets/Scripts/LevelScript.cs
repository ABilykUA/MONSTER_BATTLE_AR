using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public GameObject UI;

    public TextMeshProUGUI mHealth;
    public TextMeshProUGUI mAttack;
    public TextMeshProUGUI mDefense;


    //for switch
    private int SwitchCounter = 1;

    //GG stands 4 GamerGirl
    private Stats GG = new Stats(30, 45, 150);

    //struct for stats pretty self explanatory  
    private struct Stats
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        
        //public string Type{ get; set; }

        public Stats(int H, int D, int A) {
            Attack = A;
            Defense = D;
            Health = H;
        }

        public void hit(int value) {

            Health -= value;

        }
    }

   private void UpdateUI(Stats GG) {

        mHealth.SetText("Health: " + GG.Health);
        mAttack.SetText("Attack: " + GG.Attack); 
        mDefense.SetText("Defense: " + GG.Defense);

    }


    //function for every attack 

    //Fire
    public void FireAttack() {

        SwitchCounter = 2;
    }

    //Grass
    public void GrassBlast()
    {


        SwitchCounter = 2;
    }

    //water
    public void Water()
    {

        SwitchCounter = 2;
    }


    void Start()
    {
      
        
        //Enemy
        Stats SIMP = new Stats(15, 80, 130);

    }



    void Update()
    {

        

            switch (SwitchCounter) {

            case 1:



                UpdateUI(GG);
                UI.SetActive(true);

                break;

            case 2:




                UpdateUI(GG);
                UI.SetActive(false);

                break;


        }
    }
}
