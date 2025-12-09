using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Place
{
    private Villager _villager;
    private GameObject _villagerGraphics;
    public override void Action(Villager villager)
    {
        if (villager != _villager)
            return;
        
        var villagerGraphics = villager.transform.GetChild(0).gameObject;

        villagerGraphics.SetActive(false);
        //play Building animation
        Debug.Log("House interaction");
    }

    public override void PreAction(Villager villager)
    {
        if (villager != _villager && _villager != null)
            return;
        
        _villager = villager;
        _villagerGraphics = villager.transform.GetChild(0).gameObject;
        _villagerGraphics.SetActive(false);
    }

    public override void PostAction(Villager villager)
    {
        _villagerGraphics.SetActive(true);
        
        _villagerGraphics = null;
        _villager = null;
        
    }
}