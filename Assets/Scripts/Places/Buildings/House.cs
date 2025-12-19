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
        // Vérifications de sécurité
        if (villager == null)
        {
            Debug.LogError("Villager est null dans House.PreAction !");
            return;
        }

        if (villager.WorkAnimator == null)
        {
            Debug.LogError($"WorkAnimator est null pour {villager.name} !");
            return;
        }
        villager.BodyAnimator.SetBool("IsSleeping", true);
        print("begin to sleep");
        base.PreAction(villager);

        //_villager = villager;

        _villagerGraphics = villager.transform.GetChild(0).gameObject;

        _villagerGraphics.SetActive(false);
        villager.Data.IsTired = false;
    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        _villagerGraphics.SetActive(true);
        villager.BodyAnimator.SetBool("IsSleeping", false);

        _villagerGraphics = null;
        villager = null;
        IsOccupied = false;
        print("finished sleeping");
        base.PostAction(villager, coroutine);
    }
}