using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowVariable : MonoBehaviour, IshowVariable
{
    private TMP_Text text;

    private void Awake()
    {
        text = transform.GetComponent<TMP_Text>();
    }
}
