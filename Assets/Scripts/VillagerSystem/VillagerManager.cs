using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class VillagerManager : MonoBehaviour
{
    public VillagerDataSO _data;

    [SerializeField] public ProsperityIndicator _prosperityIndicator;


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

    private void IsGoingToDie(int age)
    {
        if (age >= 50)
        {
            OnVillagerDeath();
        }
    }


    private void KeyChangeMoodTest()
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

    private void KeyChangeAgeTest()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _data.Age += 10;
            Debug.Log($" New Age Villager : {_data.Age}");
        }
    }

}



