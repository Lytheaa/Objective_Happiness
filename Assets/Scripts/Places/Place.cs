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

    public virtual void PostAction(Villager villager, Coroutine coroutine)
    {
        if(villager.Data.WorkId == 1) print($"no mor busy?? (megamind meme) {villager.Data.WorkTarget.name}");
        villager.Data.IsBusy = false;
        coroutine = null;
    }

    public IEnumerator ActionCoroutine(Villager villager, Coroutine self)
    {
        beginActionTime = TimeManager.Inst.GlobalTime;
        PreAction(villager);

        float endTime = beginActionTime + TimeManager.Inst.HoursToSec(ActionDuration);
        while (TimeManager.Inst.GlobalTime < endTime )
        {
            if(villager.Data.WorkId == 4)
            print($"not finished yet: {TimeManager.Inst.GlobalTime} : {endTime}");
            Action(villager);
            yield return null;
        }
        PostAction(villager, self);
    }
}