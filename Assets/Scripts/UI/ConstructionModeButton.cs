using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class ConstructionModeButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> buildings;
    [SerializeField] private GameObject buildingPreviewButton;
    private void Awake()
    {
        foreach (GameObject building in buildings)
        {
            var currentButton = Instantiate(buildingPreviewButton, transform);
            currentButton.GetComponent<Button>().clicked += delegate { Instantiate(building); };
        }
    }
}
