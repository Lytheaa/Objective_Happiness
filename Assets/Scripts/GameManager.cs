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

    [Tooltip("Nombre de cueilleurs")]
    [SerializeField] private int _numberOfPickers; // Nombre de cueilleurs

    [Tooltip("Nombre de bûcherons")]
    [SerializeField] private int _numberOfWoodsman; // Nombre de bûcherons

    [Tooltip("Nombre de mineurs")]
    [SerializeField] private int _numberOfMiners; // Nombre de mineurs

    [Tooltip("Nombre de maçons")]
    [SerializeField] private int _numberOfBuilders; // Nombre de maçons

    [Tooltip("Nombre de vagabonds")]
    [SerializeField] private int _numberOfItinerants; // Nombre de vagabonds


    [Header("Script References :")]
    [SerializeField] private TimeManager _timeManager;




}
