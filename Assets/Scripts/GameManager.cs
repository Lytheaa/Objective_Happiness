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

    [Header("Available resources :")]
    [SerializeField] private int _food;
    public int Food { get { return _food; } set { _food = value; } }

    [SerializeField] private int _wood;
    public int Wood { get { return _wood; } set { _wood = value; } }

    [SerializeField] private int _stone;
    public int Stone { get { return _stone; } set { _stone = value; } }


    [Header("Prosperity indicator references :")]
    [Tooltip("Référence à l'indicateur de prospérité dans l'UI")]
    [SerializeField] private ProsperityIndicator _prosperityIndicator;
    public ProsperityIndicator ProsperityIndicator => _prosperityIndicator;

}
