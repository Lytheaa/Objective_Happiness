using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{
    public VillagerDataSO _data;
    private GameManager _gameManager;
    private Random _random = new Random();

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker (1)",1} , {"Woodsman (2)",2}, {"Miner (3)",3}, {"Builder (4)",4}, {"Itinerant (5)",5} };

    [Tooltip("Work Type of the Villager")]
    [SerializeField] public string _workType;

    ///TEST :
    int newIndex =0;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // A optimiser ?
        _data = GetComponentInParent<Villager>()._data;
    }

    private void Start()
    {
        _data.WorkIndex = SetWork();
        _workType = WorkToString(_data.WorkIndex);
    }

    private int SetWork()
    {
        int _workIndex;
        //if (_gameManager.FirstSpawn)
        //{
        //    _workIndex = SetFirstWork();
        //}
        //else
        //{
            _workIndex = SetRandomWork();
        //}
        CountNumberOfWorkers(_workIndex);
        return _workIndex;
    }

    private int SetRandomWork()
    {
        int _workIndex;
        _workIndex = _random.Next(1, _work.Count +1); 
        return _workIndex;
    }

    private int SetFirstWork() ///NE FONCTIONNE PAS 
    {
        int _workIndex;
        if (newIndex < _work.Count)
        {
            newIndex++;
        }

        _workIndex = newIndex;
        //int _workIndex = 2;

        return _workIndex;
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
