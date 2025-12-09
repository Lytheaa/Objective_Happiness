using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Events;
using UnityEngine.AI;

public class VillagerManager : MonoBehaviour
{
    public static VillagerManager Instance;

    [Header("Villagers parameters")]
    [Tooltip("Additional age added to villagers at each growth event")]
    [SerializeField] private int _additionalAge = 10;

    [Header("Villagers List")]
    [SerializeField] private List<Villager> _villagers = new List<Villager>();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterVillager(Villager villager)
    {
        _villagers.Add(villager);
    }

    public void SetAllHungry()
    {
        foreach (var villager in _villagers)
        {
            villager._data.IsHungry = true;
        }
    }

    public void GrownVillagers()
    {
        foreach (var villager in _villagers)
        {
            villager._data.Age += _additionalAge;
        }
    }

    // AUTRE VERSION : 

    public void OnEndOfDay()
    {

    }

}





