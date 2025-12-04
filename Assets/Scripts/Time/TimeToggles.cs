using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimeToggles : MonoBehaviour
{
    private List<Toggle> _togglesChildren = new();

    private void Awake()
    {
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
