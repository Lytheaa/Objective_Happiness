using System;
using UnityEngine;
//using UnityEngine.Events;

public class VillagerData : MonoBehaviour
{
    /// VARIABLES : ///
    private int _age;
    public int Age
    {
        get => _age;
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

    private int _workIndex;
    public int WorkIndex
    {
        get => _workIndex;
        set
        {
            if (_workIndex == value) return;
            _workIndex = value;
            OnWorkChange?.Invoke(_workIndex);
        }
    }


    /// EVÊNEMENTS : ///
    public event Action<int> OnAgeChange;
    public event Action<bool> OnMoodChange;
    public event Action<bool> OnTirednessChange;
    public event Action<bool> OnHungerChange;
    public event Action<int> OnWorkChange;
}
