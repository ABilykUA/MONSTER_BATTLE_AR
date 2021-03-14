using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{
    public string name { get; set; }
    public int damage { get; set; }
    public int heal { get; set; }
    public string type { get; set; }
    public int uses { get; set; }

    Abilities(string name, int damage, string type,int heal,int uses)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.heal = heal;
        this.uses = uses;
    }

}
