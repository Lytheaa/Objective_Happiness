using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class VillagerManager : MonoBehaviour
{
    public VillagerData _data;
    public IVillagerAction _actionBehaviour;

    public event Action OnMoodChange;

    public void Initialize(VillagerData data, IVillagerAction action)
    {
        _data = data;
        _actionBehaviour = action;
    }


    private void Update()
    {

    }

    //public bool MoodChange(bool isHappy)
    //{
    //    _data.IsHappy = isHappy;
    //    if (!isHappy )

    //}
}
