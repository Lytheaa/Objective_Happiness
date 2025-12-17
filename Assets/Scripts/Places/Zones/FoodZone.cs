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
    //    villager.WorkAnimator.SetBool("IsPicking", true);
    //}

    /////Ajout de ces 2 sections comparativement à Stonezone : test

    //public override void PreAction(Villager villager)
    //{
    //    base.PreAction(villager);
    //}

    //public override void PostAction(Villager villager, Coroutine coroutine)
    //{
    //    base.PostAction(villager, coroutine);
    //    //villager.WorkAnimator.SetBool("IsPicking", false);

    //}
}
