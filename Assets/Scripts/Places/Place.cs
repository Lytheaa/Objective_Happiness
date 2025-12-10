using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Place : MonoBehaviour
{
    public int[] ActionDuration = new int[3] { 8, 0, 0 }; //work lasts 8 hours by default
    
    [Header("Ressource cost")]
    public int WoodCost = 0;
    public int StoneCost = 0;
    public int BuilderCost = 0;
    
    protected float LastActionTime = 0;
    public virtual void Action(Villager villager)
    {
    }

    public virtual void Action()
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
        while (TimeManager.Inst.GlobalTime < LastActionTime + TimeManager.Inst.HoursToSec(ActionDuration))
        {
            LastActionTime = TimeManager.Inst.GlobalTime;
            Action(villager);
            yield return null;
        }
        PostAction(villager);
    }
}