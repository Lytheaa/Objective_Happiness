using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Events;
using UnityEngine.AI;

public class VillagerManager : MonoBehaviour
{
    public static VillagerManager Instance;

    private int _hungryVillagersCount = 0;
    public int HungryVillagersCount { get { return _hungryVillagersCount; } set { _hungryVillagersCount = value; } }

    [Header("Villagers parameters")]
    [Tooltip("Max age of villagers before death")]
    [SerializeField] private int _maxAge = 50;
    public int MaxAge { get { return _maxAge; } }

    [Tooltip("Additional age added to villagers at each growth event")]
    [SerializeField] private int _grownAge = 10;
    //public int AdditionalAge { get { return _additionalAge; } }

    [Header("Villagers indicators")]

    [Header("Villagers List")]
    [SerializeField] private List<Villager> _villagers = new List<Villager>();
    public List<Villager> Villagers => _villagers;

    [Header("Type of villagers")]

    [Tooltip("Nombre de cueilleurs")]
    [SerializeField] private int _numberOfPickers; // Nombre de cueilleurs
    public int NumberOfPickers { get { return _numberOfPickers; } set { _numberOfPickers = value; } }

    [Tooltip("Nombre de bûcherons")]
    [SerializeField] private int _numberOfWoodsman; // Nombre de bûcherons
    public int NumberOfWoodsman { get { return _numberOfWoodsman; } set { _numberOfWoodsman = value; } }

    [Tooltip("Nombre de mineurs")]
    [SerializeField] private int _numberOfMiners; // Nombre de mineurs
    public int NumberOfMiners { get { return _numberOfMiners; } set { _numberOfMiners = value; } }

    [Tooltip("Nombre de maçons")]
    [SerializeField] private int _numberOfBuilders; // Nombre de maçons
    public int NumberOfBuilders { get { return _numberOfBuilders; } set { _numberOfBuilders = value; } }

    [Tooltip("Nombre de vagabonds")]
    [SerializeField] private int _numberOfItinerants; // Nombre de vagabonds
    public int NumberOfItinerants { get { return _numberOfItinerants; } set { _numberOfItinerants = value; } }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RegisterVillager(Villager villager)
    {
        _villagers.Add(villager);
    }

    /// DEPLACEMENT DES VILLAGEOIS ///
    
    private void GoToWork()
    {
         foreach (var villager in _villagers)
        {
            //villager.GoToWork();
        }
    }

    private void GoToRest()
    {
        foreach (var villager in _villagers)
        {
            //villager.GoToRest();
        }
    }

    /// GESTION DE LA FATIGUE ///

    public void SetAllTired()
    {
        foreach (var villager in _villagers)
        {
            if (villager._data.WorkIndex != 5) // Les vagabonds ne se fatiguent pas
            {
                villager._data.IsTired = true;
            }
        }
    }

    /// GESTION DE L'AGE ///

    public void GrownVillagers()
    {
        foreach (var villager in _villagers)
        {
            villager._data.Age += _grownAge;
        }
    }

    /// GESTION DE LA FAIM ///

    public void SetAllHungry()
    {
        foreach (var villager in _villagers)
        {
            villager._data.IsHungry = true;
        }
    }

    public void KillHungryVillagers() // Version avec mélange
    {
        int deaths = _hungryVillagersCount;

        for (int i = 0; i < deaths; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _villagers.Count);
            Destroy(_villagers[randomIndex].gameObject);
            _villagers.RemoveAt(randomIndex);
        }

        _hungryVillagersCount = 0; // Reset après les morts
    }

}





