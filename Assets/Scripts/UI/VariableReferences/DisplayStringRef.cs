using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStringRef : MonoBehaviour
{
    [SerializeField] StringReferenceSO reference;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = reference.Reference;
    }
}
