using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodZone : Place
{
      [SerializeField] int progressAmount = 1;
      public override void Action(Villager villager)
      {
            GameManager.Instance.Wood += progressAmount;
      }


    ///Ajout de ces 2 sections comparativement à FoodZone : test

    public override void PreAction(Villager villager)
    {
        base.PreAction(villager);
        villager.WorkAnimator.SetBool("IsWoodCutting", true);
    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        base.PostAction(villager, coroutine);
        //villager.WorkAnimator.SetBool("IsWoodCutting", false);

    }
}
