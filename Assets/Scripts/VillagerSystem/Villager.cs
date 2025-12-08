using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Events;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    public VillagerDataSO _data;
    public GameManager _gameManager; // Pour accéder aux variables globales

    [Tooltip("Work Type of the Villager")]
    [SerializeField] public string _workType;

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker",1} , {"Woodsman",2}, {"Miner",3}, {"Builder",4}, {"Itinerant",5} };

    private int _hungryVillagers = 0;
    [SerializeField] private int _limitAge = 50;
    [SerializeField] private int _age;

    private Random _random = new Random();

    ////EVENTS ://
    //public static event Action OnMoodChange;
    //public static event Action OnVillagerDeath;


    //[SerializeField] public ProsperityIndicator _prosperityIndicator; //Pas utile si écouté par l'event

    /*private NavMeshAgent agent; */


    //private bool _startSpawnDone = false;


    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // A optimiser ?
    }

    private void Start()
    {
        VillagerManager.Instance.RegisterVillager(this);
        _data.WorkIndex = SetWork();
        _workType = WorkToString(_data.WorkIndex);
        _age = _data.Age;
    }

    private void Update()
    {
        KeyTestHungry();
    }

    public void Initialize(VillagerDataSO data)
    {
        _data = data;

    }

    private int SetWork()
    {
        int _workIndex;

        //if (_gameManager.NumberOfVillagers < _work.Count)
        //{
        //    _workIndex = 1;
        //}
        //else
        //{
        _workIndex = _random.Next(0, _work.Count);
        //}

        switch (_workIndex) //Ajouter au compteur de métier dans GameManager - créer une fonction dédiée ?
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

    public void FeedVillager(bool previousState)
    {
        if (_data.IsHungry != previousState)
        {
            if (_gameManager.Food > 0)
            {
                _gameManager.Food--;
                _data.IsHungry = false;
            }
            else
            {
                _hungryVillagers++;
                Debug.Log("Pas assez de nourriture pour nourrir les villageois");
            }
            Debug.Log($"Nombre de villageois affamés : {_hungryVillagers}");
        }
    }

    private void IsChangingMood(bool previousMood)
    {
        if (_data.IsHappy != previousMood)
        {
            if (!_data.IsHappy)
            {
                Debug.Log("Villageois malheureux");
                //OnMoodChange();
            }
        }
    }

    private void CheckAge(int age)
    {
        if (age >= _limitAge) // S'il est trop vieux ou affamé : déclancher la mort : A LA FIN DE LA JOURNEE 
        {
            //OnVillagerDeath();
            Destroy(this.gameObject); //A déplacer à la fin de la journée
        }
    }

    private void KeyTestHungry() //H
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!_data.IsHungry)
            {
                _data.IsHungry = true;
            }
            else
            {
                _data.IsHungry = false;
            }
            Debug.Log($" Villager is hungry : {_data.IsHungry}");
        }
    }

    //TEST EVENTS : 

    private void OnEnable()
    {
        _data.OnMoodChange.AddListener(MoodChange);
    }

    private void OnDisable()
    {
        _data.OnMoodChange.RemoveListener(MoodChange);
    }

    private void MoodChange(bool isHappy)
    {
        if (isHappy)
        {
            Debug.Log("Villageois est maintenant heureux (via event)");
        }
        else
        {
            Debug.Log("Villageois est maintenant malheureux (via event)");
        }
    }
}

//    private void Update()
//    {
//        //_metierTest = _data.WorkIndex;
//        bool _previousMood = _data.IsHappy;

//        KeyChangeMoodTest();

//        IsChangingMood(_previousMood);

//        KeyChangeAgeTest();

//        CheckAge(_data.Age);


//    }

//    private void GoToWork(Transform target)
//    {


//        //if (target != null)
//        //{
//        //    agent.SetDestination(target.position);
//        //}
//        //Récupérer la target au préalable dans l'initialisation? 
//    }

//    private void KeyChangeMoodTest() //K
//    {
//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            if (_data.IsHappy == true)
//            {
//                _data.IsHappy = false;

//            }
//            else if (_data.IsHappy == false)
//            {
//                {
//                    _data.IsHappy = true;
//                }
//            }
//            Debug.Log($" Is Happy{_data.IsHappy}");
//        }
//    }

//    private void KeyChangeAgeTest() //D
//    {
//        if (Input.GetKeyDown(KeyCode.D))
//        {
//            _data.Age += 10;
//            Debug.Log($" New Age Villager : {_data.Age}");
//        }
//    }

//}





