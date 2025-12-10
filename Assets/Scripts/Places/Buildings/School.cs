using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : Place
{
    [Range(0, 1)] [SerializeField] private float progressAmount = .1f;
    public override void Action(Villager villager)
    {
        //villager.getConversionProgressBar += progressAmount
    }

    public override void PreAction(Villager villager)
    {
        var villagerGraphics = villager.transform.GetChild(0).gameObject;
        villagerGraphics.SetActive(false);
    }

    public override void PostAction(Villager villager)
    {
        var villagerGraphics = villager.transform.GetChild(0).gameObject;
        villagerGraphics.SetActive(true);
    }
}
