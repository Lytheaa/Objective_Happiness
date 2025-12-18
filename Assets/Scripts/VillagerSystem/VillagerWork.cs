using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{
    private Villager _villager;

    private VillagerManager _villagerManager;
    private PlacesManager _placesManager;

    private Dictionary<string, int> _work = new Dictionary<string, int>()
    {{"Picker (1)",1} , {"Woodsman (2)",2}, {"Miner (3)",3}, {"Builder (4)",4}, {"Itinerant (5)",5} };

    [Tooltip("Work Type of the Villager")]
    [SerializeField] private string _workType;

    public static event Action<int, int> OnWorkChange;

    private void Awake()
    {
        _villagerManager = VillagerManager.Instance;
        _villager = GetComponentInParent<Villager>();
        _placesManager = PlacesManager.Instance;
    }

    public void SetWork(int newWorkId)
    {
        int previousWorkId = _villager.Data.WorkId;

        _villager.Data.WorkId = newWorkId;

        SetWorkPlaceTarget(newWorkId);

        _workType = WorkToString(newWorkId);

        OnWorkChange(previousWorkId, newWorkId); ///MAJ COUNTER
        SetAnimatorWork(newWorkId);

        _villagerManager.UpdateWorkersCounter();
    }

    private string WorkToString(int workIndex)
    {
        foreach (KeyValuePair<string, int> pair in _work)
        {
            if (pair.Value == workIndex)
            {
                return pair.Key;
            }
        }
        return "Unknown";
    }

    private void SetWorkPlaceTarget(int workIndex)
    {
        if (_placesManager.WorkZones.ContainsKey(workIndex))
        {
            _villager.Data.WorkTarget = _placesManager.WorkZones[workIndex];
        }
    }

    private void SetAnimatorWork(int workIndex)
    {
        switch (workIndex)
        {
            case 1: //Picker 
                _villager.WorkAnimator.SetBool("IsPicking", true);
                print("Set Animator Work");
                break;
            case 2: //Miner
                _villager.WorkAnimator.SetBool("IsWoodCutting", true);
                break;
            case 3:// Builder
                _villager.WorkAnimator.SetBool("IsWoodCutting", true);
                break;
            case 4: //Builder 
                _villager.WorkAnimator.SetBool("IsBuilding", true);
                break;
            case 5:
                /// Que faire ?
                break;

        }
    }
}
s
