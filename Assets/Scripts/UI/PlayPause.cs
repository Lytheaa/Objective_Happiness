using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Image icon;
    private bool _isPaused = false;

    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            if (_isPaused)
                icon.sprite = playSprite;
            else
                icon.sprite = pauseSprite;
            _isPaused = !_isPaused;
        });
    }
}
