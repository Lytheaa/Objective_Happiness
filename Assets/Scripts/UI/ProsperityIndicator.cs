using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProsperityIndicator : MonoBehaviour
{
    private bool _gameEnded = false;
    string _endMessage;

    private float _maxProsperityPoints = 100;
    //public int MaxProsperityPoints => _maxProsperityPoints;

    [Range(0, 100)]
    [SerializeField] private float _currentProsperityPoints = Mathf.Clamp(70, 0, 101); 
    //public int CurrentProsperityPoints => _currentProsperityPoints;

    [SerializeField] private Image _prosperityIndicator;


    public void AddProsperityPoints(float amount)
    {
        if (_gameEnded) return;
        _currentProsperityPoints += amount;
        DisplayProsperityIndicator();
    }

    public void SubstractProsperityPoints(float amount)
    {
        if (_gameEnded) return;
        _currentProsperityPoints -= amount;
        DisplayProsperityIndicator();
    }

    public void DisplayProsperityIndicator()
    {
        _prosperityIndicator.fillAmount = _currentProsperityPoints / (float)_maxProsperityPoints;
        if (_gameEnded) return;

        if (_currentProsperityPoints <= 0)
        {
            _endMessage = "You Lose !";
            _gameEnded = true;

        }
        else if (_currentProsperityPoints >= _maxProsperityPoints)
        {
            _endMessage = "You Win !";
            _gameEnded = true;
        }
    }

    private void Update() /// DEBUG - TO SUPRESS 
    {
        DisplayProsperityIndicator();

        if (_gameEnded)
        {
            UIManager.Instance.DisplayVictoryPanel(_endMessage);
        }

    }

}
