using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InConstruction : MonoBehaviour
{
    public Sprite PreviewSprite;

    private void OnEnable()
    {
        MouseManager.OnMouseMove += StickTo;
        MouseManager.OnMouseClick += OnClick;
    }

    private void OnDisable()
    {
        MouseManager.OnMouseMove -= StickTo;
    }

    private void StickTo(Vector3 position)
    {
        transform.position = position;
    }

    private void OnClick()
    {
        MouseManager.OnMouseMove -= StickTo;
    }
}