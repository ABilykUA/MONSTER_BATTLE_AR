using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public string name { get; set; }
    public int damage { get; set; }
    public int heal { get; set; }
    public string type { get; set; }
    public int uses { get; set; }

    Abilities(int damage, string type,int heal,int uses, string name)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.heal = heal;
        this.uses = uses;
    }

}
