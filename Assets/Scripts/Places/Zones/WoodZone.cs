using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodZone : Place
{
    [SerializeField] int progressAmount = 10;
    [SerializeField] float _delayToGetResource = 5f;
    //[SerializeField] int[] _delayToGetResource = new int[3] { 1, 0, 0 };
    [SerializeField] float _lastSpawn;

    public override void Action(Villager villager)
      {
        if( Time.time > _lastSpawn + _delayToGetResource)
        {
            GameManager.Instance.Wood += progressAmount;
            _lastSpawn = Time.time;
            print("cooldown");
        }

        //if (TimeManager.Inst.CurrentTime >= _lastSpawn + TimeManager.Inst.HoursToSec(_delayToGetResource)) ;
        //{
        //    GameManager.Instance.Wood += progressAmount;
        //    _lastSpawn = TimeManager.Inst.CurrentTime;
        //    print("cooldown");
        //    villager.WorkAnimator.SetBool("IsWoodCutting", true);
        //}
      }

    ///Ajout de ces 2 sections comparativement à FoodZone : test

    public override void PreAction(Villager villager)
    {
        //villager.WorkAnimator.gameObject.SetActive(true);
        print("PostAction");
        base.PreAction(villager);
    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        //villager.WorkAnimator.gameObject.SetActive(false);
        base.PostAction(villager, coroutine);


    }
}
