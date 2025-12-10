using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConstructionModeButton : MonoBehaviour
{
    [SerializeField] private List<Place> buildings;
    [SerializeField] private GameObject constructionButton;
    [SerializeField] private Transform BuildingsParent;
    
    private void Awake()
    {
        foreach (Place building in buildings)
        {
            var currentButton = Instantiate(constructionButton, transform);
            var buttonComp = currentButton.GetComponent<Button>();
            buttonComp.onClick.AddListener(delegate {  });
            buttonComp.onClick.AddListener(delegate { transform.gameObject.SetActive(false); });
            currentButton.gameObject.GetComponentsInChildren<Image>()[1].sprite = building.GetComponent<InConstruction>().PreviewSprite;
        }
    }

    private void BuyBuildings(Place building)
    {
        //if(building.WoodCost <= GameManager.Instance.Wood && ...)
        Instantiate(building);
        //else
        //not enough ressources feedback
    }
}
