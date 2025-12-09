using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//using Random = System.Random;
using UnityEngine.Events;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    public VillagerData _data;
    public GameManager _gameManager; // Pour accéder aux variables globales
    public VillagerManager _villagerManager;

    [Header("Debug Variables")] // TO SUPRESS LATER (?)

    [Tooltip("Display age propertie in inspector to check parameters")]
    [SerializeField] private int _ageDisplay;

    [Tooltip("Display hungry propertie in inspector to check parameters")]
    [SerializeField] private bool _isHungryDisplay;

    //private void Awake()
    //{
    //    //_gameManager = GameManager.Instance;
    //    //_villagerManager = VillagerManager.Instance;
    //    //_data = GetComponent<VillagerData>();


    //}

    private void Awake()
{
    _data = GetComponent<VillagerData>(); // plus fiable que GetComponentInParent
    if (_data == null)
        Debug.LogError("VillagerData MISSING on prefab !!");

    _gameManager = GameManager.Instance;
    if (_gameManager == null)
        Debug.LogError("GameManager instance is NULL !!");

    _villagerManager = VillagerManager.Instance;
    if (_villagerManager == null)
        Debug.LogError("VillagerManager instance is NULL !!");
}


    private void Start() // Lors de l'instanciation du villageois
    {
        VillagerManager.Instance.RegisterVillager(this);
    }

    private void Update()
    {
        _ageDisplay = _data.Age;
        _isHungryDisplay = _data.IsHungry;
    }

    ///EVENT LISTENER///
    private void OnEnable()
    {
        _data.OnMoodChange += MoodChange;
        _data.OnTirednessChange += TirednessChange;
        _data.OnHungerChange += FeedVillager;
        _data.OnAgeChange += CheckAge;
    }
    private void OnDisable()
    {
        _data.OnMoodChange -= MoodChange;
        _data.OnTirednessChange -= TirednessChange;
        _data.OnHungerChange -= FeedVillager;
        _data.OnAgeChange -= CheckAge;
    }

    /// METHODES LIEES AUX EVENEMENTS///

    public void FeedVillager(bool isHungry)
    {
        //if (isHungry)
        if (_data.IsHungry)
        {
            if (_gameManager.Food > 0)
            {
                _gameManager.Food--;
            }
            else
            {
                _villagerManager.HungryVillagersCount++;
            }

           _data.IsHungry = false; // Réinitialiser la faim une fois le compteur mis à jour
        }
    }

    private void CheckAge(int age)
    {
        //_ageDisplay = age;

        if (age >= _villagerManager.MaxAge) // S'il est trop vieux ou affamé : déclancher la mort
        {
            Debug.Log("Villageois est mort de vieillesse (via event)");
            Destroy(this.gameObject);
        }
    }

    private void MoodChange(bool isHappy)
    {
        if (isHappy)
        {
            Debug.Log("Villageois est maintenant heureux (via event)");
        }
        else
        {
            _gameManager.ProsperityIndicator.SubstractProsperityPoints(10); // Changer valeur
            Debug.Log("Villageois est maintenant malheureux (via event)");
        }
    }

    private void TirednessChange(bool isTired)
    {
        if (isTired)
        {
            /// Cherche une place pour dormir ? ///
            Debug.Log("Villageois est maintenant fatigué (via event)");
        }
        else
        {
            Debug.Log("Villageois n'est plus fatigué (via event)");
        }
    }


}





