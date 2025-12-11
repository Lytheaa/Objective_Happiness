using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProsperityIndicator : MonoBehaviour
{
    private float _maxProsperityPoints = 100;
    //public int MaxProsperityPoints => _maxProsperityPoints;

    [Range(0, 100)]
    [SerializeField] private float _currentProsperityPoints = Mathf.Clamp(70, 0, 100); 
    //public int CurrentProsperityPoints => _currentProsperityPoints;

    [SerializeField] private Image _prosperityIndicator;

    public void AddProsperityPoints(float amount)
    {
        _currentProsperityPoints += amount;
        DisplayProsperityIndicator();
    }

    public void SubstractProsperityPoints(float amount)
    {
        _currentProsperityPoints -= amount;
        DisplayProsperityIndicator();
    }

    public void DisplayProsperityIndicator()
    {
        _prosperityIndicator.fillAmount = _currentProsperityPoints / (float)_maxProsperityPoints;
    }

    private void Update() /// DEBUG - TO SUPRESS 
    {
        DisplayProsperityIndicator();
    }
}
