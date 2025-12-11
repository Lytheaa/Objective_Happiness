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

      public override void PreAction(Villager villager)
      {
            base.PreAction(villager);
      }

      public override void PostAction(Villager villager)
      {
            base.PostAction(villager);
      }
}
