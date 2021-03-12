using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{
    public int damage { get; set; }
    public int heal { get; set; }
    public string type { get; set; }
    public int uses { get; set; }

    Abilities(int damage, string type,int heal,int uses)
    {
        this.damage = damage;
        this.type = type;
        this.heal = heal;
        this.uses = uses;
    }

}
