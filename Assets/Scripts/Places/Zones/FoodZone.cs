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
}
