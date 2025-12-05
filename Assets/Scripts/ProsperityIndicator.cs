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
    [SerializeField] private int _currentProsperityPoints = 100; 
    //public int CurrentProsperityPoints => _currentProsperityPoints;

    [SerializeField] private Image _prosperityIndicator;


    public void AddProsperityPoints(int amount)
    {
        _currentProsperityPoints += amount;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
    }

    public void SubstractProsperityPoints(int amount)
    {
        _currentProsperityPoints -= amount;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
=======
        DisplayProsperityIndicator();

>>>>>>> Stashed changes
    }

    public void DisplayProsperityIndicator()
    {
        _prosperityIndicator.fillAmount = _currentProsperityPoints / (float)_maxProsperityPoints;
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private void Update()
    {
        DisplayProsperityIndicator();
    }
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    //private void Update()
    //{
    //    DisplayProsperityIndicator();
    //}
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}
