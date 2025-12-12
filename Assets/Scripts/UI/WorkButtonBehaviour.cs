using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkButtonBehaviour : MonoBehaviour
{
    private Toggle _toggle;

    private UIManager _manager;

    private VillagersGraphics _selected; 

    //private int _workId; 

    private void Awake()
    {
       _toggle = GetComponent<Toggle>();

    }

    private void Update()
    {
        
    }


    private void GetValueOnClick(int workId)
    {

        //_manager.
    }
}
