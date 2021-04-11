using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : Object
{
    //Name of the ability
    public string name { get; set; }
    //Damage of the ability
    public int damage { get; set; }
    //How much an ability heals (%) when used. 
    public int heal { get; set; }
    //Type/element of the ability
    public string type { get; set; }
    //Amount of uses an ability has.
    public int uses { get; set; }
    //Max amount of uses an ability can have.
    public int MaxUses { get; set; }
    //Accuracy of an ability calculated by %.
    public int SuccessRate { get; set; }
    //The type that this ability counters (is strong against).
    public string counter { get; set; }
    //Description of the ability.
    public string description { get; set; }
    //The chance that an ability can stun. (If it does stun the stunned character loses its next attack.)
    public int stun { get; set; }

    //Constructor to create a new ability
    public Abilities(int damage, string type,int heal,int uses, string name, string counter,int SuccessRate,string desc,int stun)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.heal = heal;
        this.uses = uses;
        this.MaxUses = uses;
        this.counter = counter;
        this.SuccessRate = SuccessRate;
        this.description = desc;
        this.stun = stun;
        
    }

}
