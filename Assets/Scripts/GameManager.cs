using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Available resources :")]
    [SerializeField] private int _food;
    public int Food { get { return _food; } set { _food = value; } }

    [SerializeField] private int _wood;
    public int Wood { get { return _wood; } set { _wood = value; } }

    [SerializeField] private int _stone;
    public int Stone { get { return _stone; } set { _stone = value; } }


    [Header("Type of villagers")]

    [Tooltip("Nombre de villageois total")]
    [SerializeField] private int _numberOfVillagers; // Nombre de cueilleurs
    public int NumberOfVillagers { get { return _numberOfVillagers; } set { _numberOfVillagers = value; } }

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

    [Header("Script References :")]
    [SerializeField] private ProsperityIndicator _prosperityIndicator;
    public ProsperityIndicator ProsperityIndicator => _prosperityIndicator;


    /// SPAWN de départ : à déplacer ? 

}
