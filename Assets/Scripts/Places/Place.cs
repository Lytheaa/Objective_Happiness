using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public float ActionDuration;
    protected float LastActionTime = 0;
    public virtual void Action(Villager villager)
    {
    }

    public virtual void PreAction(Villager villager)
    {
    }

    public virtual void PostAction(Villager villager)
    {
    }

    public IEnumerator ActionCoroutine(Villager villager)
    {
        PreAction(villager);
        while (TimeManager.Inst.GlobalTime < LastActionTime + ActionDuration)
        {
            LastActionTime = TimeManager.Inst.GlobalTime;
            Action(villager);
            yield return null;
        }
        PostAction(villager);
    }
}