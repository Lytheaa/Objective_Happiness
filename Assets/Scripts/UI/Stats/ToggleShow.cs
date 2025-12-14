using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UI.stats;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleShow : MonoBehaviour
{
    private Toggle _toggle;
    //private bool _isOn = false;
    [SerializeField] private UiElement element;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(delegate { element.Show(_toggle.isOn, DOTween.Sequence().SetUpdate(true)); });
    }
}