using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneZone : Place
{
    [SerializeField] int progressAmount = 10;
    [SerializeField] float _delayToGetResource = 5f;
    //[SerializeField] int[] _delayToGetResource = new int[3] { 1, 0, 0 };
    [SerializeField] float _lastSpawn;

    public override void Action(Villager villager)
    {
        if (Time.time > _lastSpawn + _delayToGetResource)
        {
            GameManager.Instance.Stone += progressAmount;
            _lastSpawn = Time.time;
            print("cooldown");
        }

    }

    public override void PreAction(Villager villager)
    {
        base.PreAction(villager);

    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        base.PostAction(villager, coroutine);

    }
}
