using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Place
{
    [SerializeField] private float foodAmountMultiplier = 1.5f;
    public override void Action(Villager villager)
    {
        var foodZonesList = GameObject.FindObjectsByType<FoodZone>(FindObjectsSortMode.None);
        foreach (FoodZone zone in foodZonesList)
        {
            zone.progressAmount *= foodAmountMultiplier;
        }
    }
}
