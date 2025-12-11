using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConstructionModeButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> buildings;
    [SerializeField] private GameObject constructionButton;
    [SerializeField] private Transform BuildingsParent;

    private void Awake()
    {
        foreach (GameObject building in buildings)
        {
            var currentButton = Instantiate(constructionButton, transform);
            var buttonComp = currentButton.GetComponent<Button>();
            buttonComp.onClick.AddListener(delegate { BuyBuildings(building.GetComponent<Place>()); });
            buttonComp.onClick.AddListener(delegate { SetVisible(false); });
            currentButton.gameObject.GetComponentsInChildren<Image>()[1].sprite =
                building.GetComponent<InConstruction>().PreviewSprite;
        }
    }

    private void BuyBuildings(Place building)
    {
        if (building.WoodCost <= GameManager.Instance.Wood &&
            building.StoneCost <= GameManager.Instance.Stone
            /*&& GameManager.instance.VillagerManager.AvailableBuilder >= building.BuilderCost*/)
        {
            GameManager.Instance.Wood -= building.WoodCost;
            GameManager.Instance.Stone -= building.StoneCost;
            //-BuilderCost
            var newBuilding = Instantiate(building, BuildingsParent);

            if (newBuilding is House)
                PlacesManager.Instance.HousesWayPoints.Add(newBuilding.transform);
            }

            if (newBuilding.TryGetComponent<School>(out School schoolComponent))
            {
                PlacesManager.Instance.SchoolWaypoints.Add(schoolComponent.transform);
            }

            PlacesManager.Instance.NewBuildings.Add(newBuilding.transform); 

        }
        else
        {
            print("not enough resources");
        }
    }

    public void SetVisible(bool visible)
    {
        if (!visible)
        {
            transform.DOScaleX(0, .2f);
        }
        else
        {
            transform.DOScaleX(1, .2f);
        }
    }
}