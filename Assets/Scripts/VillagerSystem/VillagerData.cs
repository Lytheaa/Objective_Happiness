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

    private bool _isHappy = true;
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

    private int _workId = 0;
    public int WorkId
    {
        get => _workId;
        set
        {
            if (_workId == value) return;
            _workId = value;
            OnWorkChange?.Invoke(_workId);
        }
    }

    private Transform _workTarget;
    public Transform WorkTarget
    {
        get { return _workTarget; }
        set
        {
            if (_workTarget == value) return;
            _workTarget = value;
        }
    }

    private bool _isBusy = false; 
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if(_isBusy == value) return;
            _isBusy = value;
        }
    }

    private bool _wantToGoSchool = false;
    public bool WantToGoSchool
    {
        get => _wantToGoSchool;
        set
        {
            if (_wantToGoSchool == value) return;
            _wantToGoSchool = value;

            OnTargetSchool?.Invoke(_wantToGoSchool);
        }
    }

    /// EVÊNEMENTS : ///
    public event Action<int> OnAgeChange;
    public event Action<bool> OnMoodChange;
    public event Action<bool> OnTirednessChange;
    public event Action<bool> OnHungerChange;
    public event Action<int> OnWorkChange;
    public event Action<bool> OnTargetSchool; 
}
