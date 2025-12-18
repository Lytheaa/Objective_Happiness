using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodZone : Place
{
    [SerializeField] int progressAmount = 2;
    public int ProgressAmount { get => progressAmount; set => progressAmount = value;
    }
    [SerializeField] float _delayToGetResource = 5f;
    //[SerializeField] int[] _delayToGetResource = new int[3] { 1, 0, 0 };
    [SerializeField] float _lastSpawn;

    public override void Action(Villager villager)
    {
        if (Time.time > _lastSpawn + _delayToGetResource)
        {
            GameManager.Instance.Food += progressAmount;
            _lastSpawn = Time.time;
            //print("cooldown");
        }
        //villager.WorkAnimator.SetBool("IsActive", true);
        //villager.WorkAnimator.SetBool("IsPicking", true);

    }

}
