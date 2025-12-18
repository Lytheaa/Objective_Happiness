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
    #region CHAMPS 
    private GameManager _gameManager;
    public GameManager GameManager { get { return _gameManager; } }

    private VillagerData _data;
    public VillagerData Data { get { return _data; } }

    private VillagerManager _villagerManager;
    public VillagerManager VillagerManager { get { return _villagerManager; } }

    private VillagerController _controller;
    public VillagerController Controller { get { return _controller; } }

    private VillagerWork _work;
    public VillagerWork Work { get { return _work; } }

    private VillagersGraphics _graphics;
    public VillagersGraphics Graphics { get => _graphics; set => _graphics = value; }
    [Header("Animators references")]
    [SerializeField] private Animator _bodyAnimator;
    public Animator Animator { get => _bodyAnimator; set => _bodyAnimator = value; }

    [SerializeField] private Animator _workAnimator;
    public Animator WorkAnimator { get => _workAnimator; set => _workAnimator = value; }

    [Header("Debug Variables")] // TO SUPRESS LATER (?)

    [Tooltip("Display age propertie in inspector to check parameters")]
    [SerializeField] private int _ageDisplay;

    [Tooltip("Display hungry propertie in inspector to check parameters")]
    [SerializeField] private bool _isHungryDisplay;
    [SerializeField] private bool _isTiredDisplay;
    [SerializeField] private bool _isHappyDisplay;
    [SerializeField] private Transform _workTarget;
    [SerializeField] private bool _wantToGoToSchool;
    [SerializeField] private int _futureWorkId;
    [SerializeField] private bool _isBusyDisplay;
    [SerializeField] public bool DisplayPrint = false;

    //[SerializeField] private bool _isSelected = false; 
    //public bool IsSelected { get {  return _isSelected; } } 

    public static event Action<int> OnDeath;

    #endregion

    public void Awake()
    {
        _gameManager = GameManager.Instance;
        _villagerManager = VillagerManager.Instance;
        _data = GetComponent<VillagerData>();
        _controller = GetComponent<VillagerController>();
        _work = GetComponent<VillagerWork>();
        _graphics = GetComponentInChildren<VillagersGraphics>();
    }


    private void Start()
    {
        //_workAnimator.gameObject.SetActive(false);
        _workAnimator.SetBool("IsActive", true);
    }

    private void Update()
    {
        _ageDisplay = _data.Age;
        _isHungryDisplay = _data.IsHungry;
        _isTiredDisplay = _data.IsTired;
        _isHappyDisplay = _data.IsHappy;
        _wantToGoToSchool = _data.WantToGoSchool;
        _futureWorkId = _data.FutureWorkId;
        _isBusyDisplay = _data.IsBusy;
    }

    ///EVENT LISTENER///

    private void OnEnable()
    {
       _data.OnMoodChange += MoodChange;
        _data.OnTirednessChange += TirednessChange;
        _data.OnHungerChange += FeedVillager;
        _data.OnAgeChange += CheckAge;
        //_data.OnWorkChange += CheckWork;
    }

    private void OnDisable()
    {
        if (_data == null) return;
        _data.OnMoodChange -= MoodChange;
        _data.OnTirednessChange -= TirednessChange;
        _data.OnHungerChange -= FeedVillager;
        _data.OnAgeChange -= CheckAge;
        //_data.OnWorkChange -= CheckWork;
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
                _data.IsHappy = true; // les villageois pouvant manger sont heureux
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
        if (age >= _villagerManager.MaxAge) // S'il est trop vieux ou affamé : déclancher la mort
        {
            Debug.Log("Villageois va mourir de vieillesse : event Check Age");
            Die() ;
        }
    }

    private void MoodChange(bool isHappy)
    {
        if (!isHappy)
        {
            _gameManager.ProsperityIndicator.SubstractProsperityPoints(1f); // Changer valeur
            Debug.Log("Villageois est maintenant malheureux (via event), soustraction de points de prospérité");
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

    public void Die()
    {
        Debug.Log("Villageois est mort");
        OnDeath?.Invoke(Data.WorkId);
        Destroy(this.gameObject);

    }
}





