using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Object{

    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public string Type { get; set; }
    public Abilities[] abilities = new Abilities[3];


    public Entity(int H, int D, int A, string T, Abilities Abilities) {

        this.Attack = A;
        this.Defense = D;
        this.Health = H;
        this.Type = T; 
        this.abilities[0] = Abilities;
    }

    public void Hit(int value)
    {
        Health -= value;
    }

    public Abilities GetAbilities(int i) { return abilities[i]; }
    public void SetAbilities(Abilities newAbility, int i) { abilities[i] = newAbility; }




}
