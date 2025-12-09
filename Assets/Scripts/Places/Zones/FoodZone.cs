using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodZone : Place
{
    public float progressAmount = .1f;
    public override void Action(Villager villager)
    {
        //get the game manager from future pauline's push
    }

    public override void PreAction(Villager villager)
    {
        //villager start work animation
    }

    public override void PostAction(Villager villager)
    {
        //villager ends work animation
    }
}
