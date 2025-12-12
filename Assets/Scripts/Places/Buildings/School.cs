using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : Place
{
    [Range(0, 1)] [SerializeField] private float progressAmount = .1f;
    public override void Action(Villager villager)
    {
        //villager.getConversionProgressBar += progressAmount
    }

    public override void PreAction(Villager villager)
    {
        base.PreAction(villager);

        var villagerGraphics = villager.transform.GetChild(0).gameObject;
        villagerGraphics.SetActive(false);

    }

    public override void PostAction(Villager villager)
    {
        base.PostAction(villager);

        var newWorker = villager.GetComponent<Villager>();

        if(newWorker == null)
        {
            Debug.Log("newWorker pas récup ?");
        }
        newWorker.Data.WantToGoSchool = false;
        newWorker.Work.SetWork(newWorker.Data.FutureWorkId);
        newWorker.Data.FutureWorkId = 0;

        var villagerGraphics = villager.transform.GetChild(0).gameObject;     
        villagerGraphics.SetActive(true);
        
        ///temporaryWork à vider 
    }
}
