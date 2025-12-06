using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerListener : MonoBehaviour
{
    [SerializeField] public ProsperityIndicator _prosperityIndicator;

    void OnEnable()
    {
        VillagerManager.OnMoodChange += UpdateProsperityPoints;
    }

    void OnDisable()
    {
        VillagerManager.OnMoodChange -= UpdateProsperityPoints;

    }

    void UpdateProsperityPoints()
    {
        _prosperityIndicator.SubstractProsperityPoints(10);
    }
}
