using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Object{

    //Damage/Attack of an entity
    public int Attack { get; set; }
    //Defense of an entity
    public int Defense { get; set; }
    //Health of an entity
    public double Health { get; set; }
    //Type/Element of an entity. (Stays with them until they die)
    public string Type { get; set; }
    //What element/type this entity counters.
    public string Counter { get; set; }
    //The array of ability an entity can have. 
    public Abilities[] abilities = new Abilities[3];

    //Constructor for creating a new entity
    public Entity(double H, int D, int A, string T,string C, Abilities Abilities, Abilities emptyA) {

        this.Attack = A;
        this.Defense = D;
        this.Health = H;
        this.Type = T;
        this.Counter = C;
        this.abilities[0] = Abilities;
        this.abilities[1] = emptyA;
        this.abilities[2] = emptyA;

    }
    //When an entity takes damage.
    public void Hit(double value)
    {
        //Casting it as int before issueing the damage to fix a bug where the entity would be at 0 health and still be alive.
        Health -= (int)value;
    }

    //Getter for abiltiies
    public Abilities GetAbilities(int i) { return abilities[i]; }
    //Setter for abilities
    public void SetAbilities(Abilities newAbility, int i) { abilities[i] = newAbility; }




}
