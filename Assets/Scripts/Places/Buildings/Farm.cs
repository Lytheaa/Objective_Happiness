using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Place
{
    [SerializeField] private int foodAmountMultiplier = 2;

    private void Start()
    {
        Action();
    }

    public override void Action()
    {
        var foodZonesList = FindObjectsByType<FoodZone>(FindObjectsSortMode.None);
        foreach (FoodZone zone in foodZonesList)
        {
            zone.progressAmount *= foodAmountMultiplier;
        }
    }
}
