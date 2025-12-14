using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeBuilding : Place
{
    [SerializeField] private int prosperityBonus;
    private void Awake()
    {
        TimeManager.Inst.OnDayEnds.AddListener(Action);
    }

    public override void Action()
    {
        GameManager.Instance.ProsperityIndicator.AddProsperityPoints(prosperityBonus);
    }
}
