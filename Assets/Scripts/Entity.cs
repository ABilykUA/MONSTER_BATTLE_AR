using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{

    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public string Type { get; set; }

    public Entity(int H, int D, int A, string T) {

        this.Attack = A;
        this.Defense = D;
        this.Health = H;
        this.Type = T;

    }

    public void EntityISHit(int value)
    {
        Health -= value;
    }




}
