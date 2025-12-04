using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Inst;

    private List<Toggle> _togglesChildren = new();

    private void Awake()
    {
        if(Inst == null)
            Inst = this;

        foreach (Transform child in transform)
        {
            var currentToggle = child.GetComponent<Toggle>();
            _togglesChildren.Add(currentToggle);
            currentToggle.onValueChanged.AddListener(delegate
            {
                ChangeSpeed(currentToggle);
            } );
        }
    }
    private void ChangeSpeed(Toggle source)
    {
        Time.timeScale = source.GetComponent<TimeInfo>().timeSpeed;
    }
}
