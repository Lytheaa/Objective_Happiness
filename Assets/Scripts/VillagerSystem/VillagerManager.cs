using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random; 
using UnityEngine.Events;
using UnityEngine.AI;

public class VillagerManager : MonoBehaviour
{
    public VillagerDataSO _data;
    [SerializeField] public int _metierTest;

    //EVENTS ://
    public static event Action OnMoodChange;
    public static event Action OnVillagerDeath;

    [SerializeField] public GameManager _gameManager;
    [SerializeField] public ProsperityIndicator _prosperityIndicator; //Pas utile si écouté par l'event
    /*private NavMeshAgent agent; */

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    { {"Picker",1} , {"Woodsman",2}, {"Miner",3}, {"Builder",4}, {"Itinerant",5} };

    private Random _random = new Random();


    public IVillagerAction _actionBehaviour;


    public void Initialize(VillagerDataSO data/*, IVillagerAction action*/)
    {
        _data = data;


        /* _actionBehaviour = action;*/
    }

    private void Start()
    {
        _data.Age = 1;

        /// Choisir métier d'origine //
        _data.WorkIndex = ChooseWork();
        _metierTest = _data.WorkIndex;

    }

    private int ChooseWork()
    {
        // Si c'est au Start du jeu ? 1 de chaque métier dispo 

        //Choisir un métier au hasard parmi les métiers disponibles
        int _randomWorkIndex = _random.Next(1, _work.Count +1);
        return _randomWorkIndex;
    }

    private void Update()
    { 
        //_metierTest = _data.WorkIndex;
        bool _previousMood = _data.IsHappy;

        KeyChangeMoodTest();

        IsChangingMood(_previousMood);

        KeyChangeAgeTest();

        CheckAge(_data.Age);
        
    }

    private void IsChangingMood(bool previousMood)
    {
        if (_data.IsHappy != previousMood)
        {
            if (_data.IsHappy == false)
            {
                Debug.Log("Villageois malheureux");
                OnMoodChange();
            }
        }
    }


    private void WantToEat(bool previousState)
    {
        if(_data.IsHungry != previousState) //Le Villageois change d'état de faim
        {
            if(_data.IsHungry == true)
            {
                Debug.Log("Villageois affamé");
                //Ajouter event manger

                // déduire -1 de la variable de ressource nourriture globale   
                // si la variable ressource nourriture globale > 0
                //      _data.IsHungry = false;

            }
        }
    }

    private void CheckAge(int age)
    {
        if (age >= 50 | _data.IsHungry == false) // S'il est trop vieux ou affamé : déclancher la mort : A LA FIN DE LA JOURNEE 
        {
            OnVillagerDeath();
            //Destroy(this.gameObject); //A déplacer à la fin de la journée
        }
    }

    private void GoToWork(Transform target)
    {

        
        //if (target != null)
        //{
        //    agent.SetDestination(target.position);
        //}
        //Récupérer la target au préalable dans l'initialisation? 
    }

    private void KeyChangeMoodTest() //K
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_data.IsHappy == true)
            {
                _data.IsHappy = false;

            }
            else if (_data.IsHappy == false)
            {
                {
                    _data.IsHappy = true;
                }
            }
            Debug.Log($" Is Happy{_data.IsHappy}");
        }
    }

    private void KeyChangeAgeTest() //D
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _data.Age += 10;
            Debug.Log($" New Age Villager : {_data.Age}");
        }
    }




}



