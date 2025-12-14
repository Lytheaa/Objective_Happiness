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

        //var villagerGraphics = villager.transform.GetChild(0).gameObject; //ca marche pas encore
        // if (villagerGraphics = null)
        // {
        //     Debug.Log("villagers graphics null !");
        // }
        // villagerGraphics.SetActive(false);

    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        Debug.Log("newWorker r�cup�r� ? ");

        var newWorker = villager;
        if(newWorker == null)
        {
            Debug.Log("newWorker pas r�cup ?");
        }
        newWorker.Data.WantToGoSchool = false;
        newWorker.Work.SetWork(newWorker.Data.FutureWorkId);
        newWorker.Data.FutureWorkId = 0;
        
        // var villagerGraphics = villager.transform.GetChild(0).gameObject;     
        // villagerGraphics.SetActive(true);
        
        ///temporaryWork � vider
        base.PostAction(villager, coroutine);
    }
}
