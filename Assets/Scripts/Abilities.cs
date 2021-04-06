using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : Object
{
    public string name { get; set; }
    public int damage { get; set; }
    public int heal { get; set; }
    public string type { get; set; }
    public int uses { get; set; }
    public int MaxUses { get; set; }
    public int SuccessRate { get; set; }
    public string counter { get; set; }

    public Abilities(int damage, string type,int heal,int uses, string name, string counter,int SuccessRate)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.heal = heal;
        this.uses = uses;
        this.MaxUses = uses;
        this.counter = counter;
        this.SuccessRate = SuccessRate;
    }

}
