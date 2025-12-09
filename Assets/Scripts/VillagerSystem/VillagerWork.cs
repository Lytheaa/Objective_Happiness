using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{
    public VillagerData _data;
    private GameManager _gameManager;
    private Random _random = new Random();

    private bool _firstSpawn = true;

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker (1)",1} , {"Woodsman (2)",2}, {"Miner (3)",3}, {"Builder (4)",4}, {"Itinerant (5)",5} };

    [Tooltip("Work Type of the Villager")]
    [SerializeField] public string _workType;

    ///TEST :
    //int newIndex =0;

    private void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // A optimiser ?
        _gameManager = GameManager.Instance;
        _data = GetComponentInParent<VillagerData>();
        _data.WorkIndex = 0;
        Debug.Log($"Work Index at Awake: {_data.WorkIndex}");

    }

    private void Start()
    {
        //_data.WorkIndex = SetWork();
        //_workType = WorkToString(_data.WorkIndex);
        int newRandomIndex = _random.Next(1, 6);

        this.AttributeWork(newRandomIndex);

        Debug.Log($"Work Index on Start: {_data.WorkIndex}");


    }

    private void Update()
    {
        _workType = WorkToString(_data.WorkIndex);
    }


    //public void Initialize(VillagerDataSO data)
    //{
    //    _data = data;
    //}


    public void AttributeWork(int workIndex)
    {
        _data.WorkIndex = workIndex;

        Debug.Log($"Work Index SO: {_data.WorkIndex}");
        Debug.Log($"Work Index Method : {workIndex}");

        //workIndex = _data.WorkIndex;
        _workType = WorkToString(_data.WorkIndex);

    }

    public int SetWork()
    {
        int _workIndex;
        if (!_firstSpawn)
        {
           _workIndex = _random.Next(1, 6); // 1 to 5 inclusive

        } else
        {
            _workIndex = 3; // First spawn test
        }

        CountNumberOfWorkers(_workIndex);

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

