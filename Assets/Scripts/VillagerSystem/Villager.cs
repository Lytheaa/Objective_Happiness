using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Random = System.Random;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Villager : MonoBehaviour
{
    public VillagerData _data;
    public GameManager _gameManager; // Pour accéder aux variables globales
    public VillagerManager _villagerManager;

    private VillagerControler _controler;
    public VillagerControler Controler { get { return _controler; } }

    [Header("Debug Variables")] // TO SUPRESS LATER (?)

    [Tooltip("Display age propertie in inspector to check parameters")]
    [SerializeField] private int _ageDisplay;

    [Tooltip("Display hungry propertie in inspector to check parameters")]
    [SerializeField] private bool _isHungryDisplay;

    [SerializeField] private bool _isTiredDisplay;

    [SerializeField] private Transform _workTarget;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _villagerManager = VillagerManager.Instance;
        _data = GetComponent<VillagerData>();
        _controler = GetComponent<VillagerControler>();
    }

    private void Start() // Lors de l'instanciation du villageois
    {
        VillagerManager.Instance.RegisterVillager(this);
    }

    private void Update()
    {
        _ageDisplay = _data.Age;
        _isHungryDisplay = _data.IsHungry;
        _isTiredDisplay = _data.IsTired;
    }

    ///EVENT LISTENER///
    private void OnEnable()
    {
        _data.OnMoodChange += MoodChange;
        _data.OnTirednessChange += TirednessChange;
        _data.OnHungerChange += FeedVillager;
        _data.OnAgeChange += CheckAge;
        _data.OnWorkChange += SetWorkTarget;
    }
    private void OnDisable()
    {
        _data.OnMoodChange -= MoodChange;
        _data.OnTirednessChange -= TirednessChange;
        _data.OnHungerChange -= FeedVillager;
        _data.OnAgeChange -= CheckAge;
        _data.OnWorkChange -= SetWorkTarget;

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
            /// VillagerControler.GoToSleep();
            Debug.Log("Villageois est maintenant fatigué (via event)");
        }
        else
        {
            Debug.Log("Villageois n'est plus fatigué (via event)");
        }
    }

    private void SetWorkTarget(int work)
    {
        Transform newWorkTarget;

        foreach (Transform zone in _workZonesWaypoints)
        {
            switch (work)
            {
                case 1: //Picker
                newWorkTarget = zone.GetComponent<FoodZone>().transform;
                    break;
                case 2: //Woodsman
                newWorkTarget = zone.GetComponent<Forest>().transform;
                    break;
                case 3: //Miner
                newWorkTarget = zone.GetComponent<StoneZone>().transform;
                    break;
                case 4:
                    Debug.Log($"Zone work target = maçon");
                    break;
            }
        }
}





