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
    private int _hungryVillagers = 0;
    [SerializeField] private int _limitAge = 50;
    [SerializeField] private int _ageDisplay;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _data = this.GetComponent<VillagerData>();
        _data.Age = 0;
    }

    private void Start() // Lors de l'instanciation du villageois
    {
        VillagerManager.Instance.RegisterVillager(this);
        _gameManager.NumberOfVillagers++; // Ajouter au compteur de villageois total dans GameManager ? 
    }

    private void Update()
    {
        _ageDisplay = _data.Age;
        KeyChangeMoodTest();
    }

    ///EVÊNEMENTS/// 

    //private void OnEnable()
    //{
    //    _data.OnMoodChange.AddListener(MoodChange);
    //    _data.OnTirednessChange.AddListener(TirednessChange);
    //    _data.OnHungerChange.AddListener(FeedVillager);
    //    _data.OnAgeChange.AddListenerCheckAge);
    //}

    //private void OnDisable()
    //{
    //    _data.OnMoodChange.RemoveListener(MoodChange);
    //    _data.OnTirednessChange.RemoveListener(TirednessChange);
    //    _data.OnHungerChange.RemoveListener(FeedVillager);
    //    _data.OnAgeChange.RemoveListener(CheckAge);

    //}

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
        if (isHungry)
        {
            if (_gameManager.Food > 0)
            {
                _gameManager.Food--;
                _data.IsHungry = false;
            }
            else
            {
                _hungryVillagers++;
                Debug.Log("Pas assez de nourriture pour nourrir les villageois");
            }
            Debug.Log($"Nombre de villageois affamés : {_hungryVillagers}");
        }
    }

    private void CheckAge(int age)
    {
        if (age >= _limitAge) // S'il est trop vieux ou affamé : déclancher la mort : A LA FIN DE LA JOURNEE 
        {
            Debug.Log("Villageois est mort de vieillesse (via event)");
            //Destroy(this.gameObject); //A déplacer à la fin de la journée
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

    ///KEYTESTS///

    //private void KeyTestHungry() //H
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        if (!_data.IsHungry)
    //        {
    //            _data.IsHungry = true;
    //        }
    //        else
    //        {
    //            _data.IsHungry = false;
    //        }
    //        Debug.Log($" Villager is hungry : {_data.IsHungry}");
    //    }
    //}

    private void KeyChangeMoodTest() //K
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_data.IsHappy == true)
            {
                _data.IsHappy = false;

            }
            else if (_data.IsHappy == false)
            {
                {
                    _data.IsHappy = true;
                }
            }
            Debug.Log($" Is Happy{_data.IsHappy}");
        }
    }


}





