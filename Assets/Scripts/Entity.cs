﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Object{

    public int Attack { get; set; }
    public int Defense { get; set; }
    public double Health { get; set; }
    public string Type { get; set; }
    public string Counter { get; set; }
    public Abilities[] abilities = new Abilities[3];


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

    public void Hit(double value)
    {
        Health -= value;
    }

    public Abilities GetAbilities(int i) { return abilities[i]; }
    public void SetAbilities(Abilities newAbility, int i) { abilities[i] = newAbility; }




}
