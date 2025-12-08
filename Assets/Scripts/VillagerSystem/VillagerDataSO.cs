using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SO/VillagerData")]
public class VillagerDataSO : ScriptableObject
{
    private int _age;
    public int Age { get => _age; set => _age = value; }

    //private bool _isAlive;
    //public bool IsAlive { get => _isAlive; set => _isAlive = value; }

    private bool _isHappy;
    public bool IsHappy
    {
        get => _isHappy;
        set
        {
            if (_isHappy == value) return;
            _isHappy = value;
            OnMoodChange?.Invoke(_isHappy);
        }
    }

    public UnityEvent<bool> OnMoodChange = new UnityEvent<bool>();

    private bool _isTired; 
    public bool IsTired { get => _isTired; set => _isTired = value; }

    private bool _isHungry;
    public bool IsHungry { get => _isHungry; set => _isHungry = value; }

    //private Dictionary<string, int> _work = new Dictionary<string, int>() 
    //{ {"Picker",1} , {"Woodsman",2}, {"Miner",3}, {"Builder",4}, {"Itinerant",5} };

    private int _workIndex;
    public int WorkIndex { get => _workIndex; set => _workIndex = value; }

}
