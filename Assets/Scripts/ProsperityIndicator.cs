using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProsperityIndicator : MonoBehaviour
{
    [Range(0,100)]
    private int _maxProsperityPoints = 100;
    //public int MaxProsperityPoints => _maxProsperityPoints;
    [Range(0, 100)]
    [SerializeField] private int _currentProsperityPoints = Mathf.Clamp(70, 0, 100); 
    //public int CurrentProsperityPoints => _currentProsperityPoints;

    [SerializeField] private Image _prosperityIndicator;

    public void AddProsperityPoints(int amount)
    {
        _currentProsperityPoints += amount;
        DisplayProsperityIndicator();
    }

    public void SubstractProsperityPoints(int amount)
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
