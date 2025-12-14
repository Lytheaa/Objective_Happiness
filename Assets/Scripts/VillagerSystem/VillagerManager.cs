using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Events;
using UnityEngine.AI;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class VillagerManager : MonoBehaviour
{
    public static VillagerManager Instance;

    private Dictionary<int, int> _workersCount = new Dictionary<int, int>()
    { {1, 0}, {2, 0}, {3,0}, {4,0}, {5,0} };

    [Header("Villagers parameters")]
    [Tooltip("Max age of villagers before death")]
    [SerializeField] private int _maxAge = 50;
    public int MaxAge { get { return _maxAge; } }

    [Tooltip("Additional age added to villagers at each growth event")]
    [SerializeField] private int _grownAge = 10;
    //public int AdditionalAge { get { return _additionalAge; } }

    [Header("Villagers indicators")]
    [Tooltip("Nombre de villageois affam�s")]
    /*[SerializeField]*/
    private int _hungryVillagersCount = 0;
    public int HungryVillagersCount { get { return _hungryVillagersCount; } set { _hungryVillagersCount = value; } }

    [Header("Villagers List")]
    [SerializeField] private List<Villager> _villagers = new List<Villager>();
    public List<Villager> Villagers => _villagers;

    [Header("Type of villagers")]

    [Tooltip("Nombre de cueilleurs")]
    [SerializeField] private int _numberOfPickers; // Nombre de cueilleurs

    [Tooltip("Nombre de b�cherons")]
    [SerializeField] private int _numberOfWoodsman; // Nombre de b�cherons

    [Tooltip("Nombre de mineurs")]
    [SerializeField] private int _numberOfMiners; // Nombre de mineurs

    [Tooltip("Nombre de ma�ons")]
    [SerializeField] private int _numberOfBuilders; // Nombre de ma�ons

    [Tooltip("Nombre de vagabonds")]
    [SerializeField] private int _numberOfItinerants; // Nombre de vagabonds
    
    [FormerlySerializedAs("_PickerAmount")]
    [Header("Ui References SO")]
    [SerializeField] private StringReferenceSO pickerAmount;
    [SerializeField] private StringReferenceSO minerAmount;
    [SerializeField] private StringReferenceSO builderAmount;
    [SerializeField] private StringReferenceSO woodWorkerAmount;
    [SerializeField] private StringReferenceSO itinerantAmount;
    [SerializeField] private StringReferenceSO villagerAmount;
    [SerializeField] private StringReferenceSO happyAmount;
    [SerializeField] private StringReferenceSO sadAmount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        //ugly but there's no more time
        pickerAmount.Reference = _numberOfPickers.ToString();
        minerAmount.Reference = _numberOfMiners.ToString();
        builderAmount.Reference = _numberOfBuilders.ToString();
        woodWorkerAmount.Reference = _numberOfWoodsman.ToString();
        itinerantAmount.Reference = _numberOfItinerants.ToString();
        villagerAmount.Reference = _villagers.Count.ToString();
        
        //getting all happy and sad people
        int happyCount = 0;
        foreach (var villager in _villagers)
        {
            if(villager.Data.IsHappy) happyCount++;
        }

        int sadCount = _villagers.Count - happyCount;
        happyAmount.Reference = happyCount.ToString();
        sadAmount.Reference = sadCount.ToString();
        
    }

    public void RegisterVillager(Villager villager)
    {
        _villagers.Add(villager);
    }

    /// DEPLACEMENT DES VILLAGEOIS ///

    public void WorkTime()
    {
        /// S'il n'est pas fatiqu� ajouter condition : 
        foreach (var villager in _villagers)
        {
            if (villager != null && villager.Controller != null)
            {
                if (villager.Data.WantToGoSchool)
                {
                    villager.Controller.GoToSchool();
                } else
                {
                    villager.Controller.GoToWork();
                }
            }
        }
    }

    public void TimeToRest()
    {
        foreach (var villager in _villagers)
        {
            if (villager.Data.WorkId > 0 && villager.Data.WorkId < 5) /// Si les villageois ont un m�tier autre que vagabond 
            {
                villager.Controller.GoToSleep();
            }
        }
    }

    /// GESTION DE LA FATIGUE ///

    public void SetAllTired()
    {
        foreach (var villager in _villagers)
        {
            if (villager.Data.WorkId != 5) // Les vagabonds ne se fatiguent pas
            {
                villager.Data.IsTired = true;
            }
        }
    }

    /// GESTION DE L'AGE ///

    public void GrownVillagers()
    {
        foreach (var villager in _villagers)
        {
            villager.Data.Age += _grownAge;
        }
    }

    /// GESTION DE l'HUMEUR ///

    public void SetAllSad()
    {
        foreach (var villager in _villagers)
        {
            villager.Data.IsHappy = false;
        }
    }

    /// GESTION DE LA FAIM ///

    public void SetAllHungry()
    {
        foreach (var villager in _villagers)
        {
            villager.Data.IsHungry = true;
        }
    }

    public void KillHungryVillagers() // Version avec m�lange
    {
        if (HungryVillagersCount > 0)
        {
            int deaths = _hungryVillagersCount;

            for (int i = 0; i < deaths; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, _villagers.Count);
                Villager villager = _villagers[randomIndex];
                villager.Die();
                _villagers.RemoveAt(randomIndex);
            }
            _hungryVillagersCount = 0; // Reset apr�s les morts

            SetAllSad(); ///Tous les villageois encore vivants sont tristes � cause de la famine 
        }
    }

    /// VILLAGER COUNTER :/// 

    private void OnEnable()
    {
        VillagerWork.OnWorkChange += ChangeWorkersCountersValues;
        Villager.OnDeath += SubstractWorkersCounter;
    }

    private void OnDisable()
    {
        VillagerWork.OnWorkChange -= ChangeWorkersCountersValues;
        Villager.OnDeath -= SubstractWorkersCounter;
    }

    private void ChangeWorkersCountersValues(int previousWorkId, int newWorkId)
    {
        SubstractWorkersCounter(previousWorkId);

        if (_workersCount.ContainsKey(newWorkId))
        {
            _workersCount[newWorkId]++;
        }
        else
        {
            _workersCount[newWorkId] = 1;
        }
        UpdateWorkersCounter();
    }

    private void SubstractWorkersCounter(int workId)
    {
        if (_workersCount.ContainsKey(workId))
        {
            _workersCount[workId]--;

            if (_workersCount[workId] <= 0)
            {
                _workersCount.Remove(workId);
            }
        }
        UpdateWorkersCounter();
    }

    public void UpdateWorkersCounter()
    {
        _workersCount.TryGetValue(1, out _numberOfPickers);
        _workersCount.TryGetValue(2, out _numberOfWoodsman);
        _workersCount.TryGetValue(3, out _numberOfMiners);
        _workersCount.TryGetValue(4, out _numberOfBuilders);
        _workersCount.TryGetValue(5, out _numberOfItinerants);
    }
}





