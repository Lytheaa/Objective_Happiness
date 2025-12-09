using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{
    private VillagerData _data;
    private VillagerManager _villagerManager;

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker (1)",1} , {"Woodsman (2)",2}, {"Miner (3)",3}, {"Builder (4)",4}, {"Itinerant (5)",5} };

    [Tooltip("Work Type of the Villager")]
    [SerializeField] private string _workType;

    private void Awake()
    {
        _villagerManager = VillagerManager.Instance;

        _data = GetComponentInParent<VillagerData>();
    }

    public void SetWork(int workIndex)
    {
        _data.WorkIndex = workIndex;
        _workType = WorkToString(workIndex);
        CountNumberOfWorkers(workIndex);
    }

    private string WorkToString(int workIndex)
    {
        foreach (KeyValuePair<string, int> pair in _work)
        {
            if (pair.Value == workIndex)
            {
                return pair.Key;
            }
        }
        return "Unknown";
    }

    private void CountNumberOfWorkers(int workIndex)
    {
        switch (workIndex) //Ajouter au compteur de métier dans GameManager - créer une fonction dédiée ?
        {
            case 1: //Picker
                _villagerManager.NumberOfPickers++;
                break;
            case 2: //Woodsman
                _villagerManager.NumberOfWoodsman++;
                break;
            case 3: //Miner
                _villagerManager.NumberOfMiners++;
                break;
            case 4: //Builder
                _villagerManager.NumberOfBuilders++;
                break;
            case 5: //Itinerant
                _villagerManager.NumberOfItinerants++;
                break;
        }

    }

}

