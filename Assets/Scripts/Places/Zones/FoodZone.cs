using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodZone : Place
{
    public int progressAmount = 1;
    public override void Action(Villager villager)
    {
        GameManager.Instance.Food += progressAmount;
    }

    public override void PreAction(Villager villager)
    {
        //villager start work animation
        base.PreAction(villager);
    }

    public override void PostAction(Villager villager)
    {
        //villager ends work animation
        base.PostAction(villager);

    }
}
