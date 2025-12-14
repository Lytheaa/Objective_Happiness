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
    
    protected float beginActionTime = 0;
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
        villager.Data.IsBusy = false;
    }

    public IEnumerator ActionCoroutine(Villager villager)
    {
        beginActionTime = TimeManager.Inst.GlobalTime;
        PreAction(villager);

        float endTime = beginActionTime + TimeManager.Inst.HoursToSec(ActionDuration);
        while (TimeManager.Inst.GlobalTime < endTime )
        {
            Action(villager);
            yield return null;
        }
        PostAction(villager);
    }
}