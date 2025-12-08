using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class VillagerManager : MonoBehaviour
{
    public VillagerDataSO _data;

    [SerializeField] public GameManager _gameManager;
    [SerializeField] public ProsperityIndicator _prosperityIndicator; //Pas utile si écouté par l'event
    /*private NavMeshAgent agent; */ 

    public static event Action OnMoodChange;
    public static event Action OnVillagerDeath;

    //EVENTS ://
    public IVillagerAction _actionBehaviour;


    public void Initialize(VillagerDataSO data/*, IVillagerAction action*/)
    {
        _data = data;
        /* _actionBehaviour = action;*/
    }

    private void Awake()
    {
        _data.Age = 1;
    }

    private void Update()
    {
        bool _previousMood = _data.IsHappy;

        KeyChangeMoodTest();

        IsChangingMood(_previousMood);

        KeyChangeAgeTest();

        IsGoingToDie(_data.Age);

        //if (_data.IsHappy != previousMood)
        //{
        //    if (_data.IsHappy == false)
        //    {
        //        Debug.Log("Villageois malheureux");
        //        OnMoodChange();
        //    }
        //}
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

    private void IsGoingToDie(int age)
    {
        if (age >= 50 | _data.IsHungry == false) // S'il est trop vieux ou affamé : déclancher la mort : A LA FIN DE LA JOURNEE 
        {
            OnVillagerDeath();
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



