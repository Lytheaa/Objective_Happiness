using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UI.stats;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour
{
    private Vector3 _initialPos;
    private float _initialHeight;
    private RectTransform _rectTransform;
    private bool _activate = true;
    
    [SerializeField] private Button _button;
    [SerializeField] private float openedYOffsetPos = 300;
    [SerializeField] private List<UiElement> advancedStatsUI = new List<UiElement>();

    private void Awake()
    {
        _initialPos = transform.position;
        _rectTransform = GetComponent<RectTransform>();
        _button.onClick.AddListener(delegate { OpenStats(_activate); });
    }

    private void Update()
    {
        //print(GetComponent<RectTransform>().sizeDelta);
    }

    private void OpenStats(bool activate)
    {
        if (activate)
        {
            _rectTransform.DOSizeDelta(new Vector2(_rectTransform.sizeDelta.x, _rectTransform.sizeDelta.y + openedYOffsetPos), .2f);
        }
        else
        {
            _rectTransform.DOSizeDelta(new Vector2(_rectTransform.sizeDelta.x, _rectTransform.sizeDelta.y - openedYOffsetPos), .2f);
        }
        foreach (var ui in advancedStatsUI)
        {
            ui.Show(activate);
        }
        _activate = !activate;
    }
}
