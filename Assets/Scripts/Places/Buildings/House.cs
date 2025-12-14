using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Place
{
    private Villager _villager;
    private GameObject _villagerGraphics;
    public bool IsOccupied = false;
    public override void Action(Villager villager)
    {
        Debug.Log("sleeping");
    }

    public override void PreAction(Villager villager)
    {
        base.PreAction(villager);
        
        _villager = villager;
        _villagerGraphics = villager.transform.GetChild(0).gameObject;

        _villagerGraphics.SetActive(false);
        _villager.Data.IsTired = false;
    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        _villagerGraphics.SetActive(true);
        
        _villagerGraphics = null;
        _villager = null;
        IsOccupied = false;
        base.PostAction(villager, coroutine);
    }
}