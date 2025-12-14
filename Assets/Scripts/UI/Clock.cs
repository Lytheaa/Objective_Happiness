using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private TMP_Text _display;

    private void Awake()
    {
        _display = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        var time = TimeManager.Inst.TimeInHours;
        _display.text = $"{time[0]} : {time[1]}";
    }
}
