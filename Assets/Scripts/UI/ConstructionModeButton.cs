using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConstructionModeButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> buildings;
    [SerializeField] private GameObject constructionButton;
    
    private void Awake()
    {
        foreach (GameObject building in buildings)
        {
            var currentButton = Instantiate(constructionButton, transform);
            var buttonComp = currentButton.GetComponent<Button>();
            buttonComp.onClick.AddListener(delegate { Instantiate(building); });
            buttonComp.onClick.AddListener(delegate { transform.gameObject.SetActive(false); });
            currentButton.gameObject.GetComponentsInChildren<Image>()[1].sprite = building.GetComponent<InConstruction>().PreviewSprite;
        }
    }
}
