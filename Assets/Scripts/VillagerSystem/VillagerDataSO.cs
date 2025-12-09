using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SO/VillagerData")]
public class VillagerDataSO : ScriptableObject
{
    /// METHODES PUBLIQUES POUR GERER LES EVENTS : Elles permettent de déclencher un évènement à chaque changement de valeur/// 
    private int _age;
    public int Age { get => _age;
        set
        {
            if (_age == value) return;
            _age = value;
            OnAgeChange?.Invoke(_age);
        }
        }

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
    
    private bool _isTired;
    public bool IsTired
    {
        get => _isTired;
        set
        {
            if (_isTired = value) return;
            _isTired = value;
            OnTirednessChange?.Invoke(_isTired);
        }
    }

    private bool _isHungry;
    public bool IsHungry
    {
        get => _isHungry; set
        {
            if (_isHungry == value) return;
            _isHungry = value;
            OnHungerChange?.Invoke(_isHungry);
        }
    }

    private int _workIndex = 0;
    public int WorkIndex 
    { get => _workIndex;
        set
        {
            if (_workIndex == value) return;
            _workIndex = value;
            OnWorkChange?.Invoke(_workIndex);
        }
        }


    /// EVÊNEMENTS : ///
    public UnityEvent<int> OnAgeChange = new UnityEvent<int>();

    public UnityEvent<bool> OnMoodChange = new UnityEvent<bool>();

    public UnityEvent<bool> OnTirednessChange = new UnityEvent<bool>();

    public UnityEvent<bool> OnHungerChange = new UnityEvent<bool>();

    public UnityEvent<int> OnWorkChange = new UnityEvent<int>();


}
