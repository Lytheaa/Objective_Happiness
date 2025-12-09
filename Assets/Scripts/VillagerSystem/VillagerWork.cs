using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{
    private VillagerData _data;
    private GameManager _gameManager;

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker (1)",1} , {"Woodsman (2)",2}, {"Miner (3)",3}, {"Builder (4)",4}, {"Itinerant (5)",5} };

    [Tooltip("Work Type of the Villager")]
    [SerializeField] private string _workType;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _data = GetComponentInParent<VillagerData>();
        Debug.Log($"Work Index at Awake: {_data.WorkIndex}");
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
                _gameManager.NumberOfPickers++;
                break;
            case 2: //Woodsman
                _gameManager.NumberOfWoodsman++;
                break;
            case 3: //Miner
                _gameManager.NumberOfMiners++;
                break;
            case 4: //Builder
                _gameManager.NumberOfBuilders++;
                break;
            case 5: //Itinerant
                _gameManager.NumberOfItinerants++;
                break;
        }

    }

}

