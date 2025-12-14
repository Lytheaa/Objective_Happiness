using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton

    public VillagerManager _villagerManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _villagerManager = VillagerManager.Instance;
    }

    private void Update()
    {
        int globalResources = _stone + _wood;
        globalResourcesAmount.Reference = globalResources.ToString();
        foodAmount.Reference = _food.ToString();
        woodAmount.Reference = _wood.ToString();
        stoneAmount.Reference = _stone.ToString();
    }

    [Header("Available resources :")]
    [SerializeField] private int _food;
    public int Food { get { return _food; } set { _food = value; } }

    [SerializeField] private int _wood;
    public int Wood { get { return _wood; } set { _wood = value; } }

    [SerializeField] private int _stone;
    public int Stone { get { return _stone; } set { _stone = value; } }


    [Header("Prosperity indicator references :")]
    [Tooltip("R�f�rence � l'indicateur de prosp�rit� dans l'UI")]
    [SerializeField] private ProsperityIndicator _prosperityIndicator;
    public ProsperityIndicator ProsperityIndicator => _prosperityIndicator;
    
    [Header("Ui References SO")]
    [SerializeField] private StringReferenceSO foodAmount;
    [SerializeField] private StringReferenceSO woodAmount;
    [SerializeField] private StringReferenceSO stoneAmount;
    [SerializeField] private StringReferenceSO globalResourcesAmount;

}
