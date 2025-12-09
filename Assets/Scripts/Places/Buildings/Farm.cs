using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Place
{
    [SerializeField] private float foodAmountMultiplier = 1.5f;

    private void Start()
    {
        Action();
    }

    public override void Action(Villager villager)
    {
        var foodZonesList = FindObjectsByType<FoodZone>(FindObjectsSortMode.None);
        foreach (FoodZone zone in foodZonesList)
        {
            zone.progressAmount *= foodAmountMultiplier;
        }
    }
}
