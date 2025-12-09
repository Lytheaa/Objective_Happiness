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

    public int _hungryVillagersCount = 0;

    [Header("Villagers parameters")]
    [Tooltip("Additional age added to villagers at each growth event")]
    [SerializeField] private int _additionalAge = 10;

    [Header("Villagers List")]
    [SerializeField] private List<Villager> _villagers = new List<Villager>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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

    public void SetAllTired()
    {
        foreach (var villager in _villagers)
        {
            if (villager._data.WorkIndex != 5) // Les vagabonds ne se fatiguent pas
            {
                villager._data.IsTired = true;
            }
        }
    }

    public void GrownVillagers()
    {
        foreach (var villager in _villagers)
        {
            villager._data.Age += _additionalAge;
        }
    }

    public void KillHungryVillagers()
    {
        for (int i = 0; i < _hungryVillagersCount; i++)
        {
            Destroy(_villagers[i].gameObject);
            _villagers.RemoveAt(i);
        }
    }

}





