using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersList : MonoBehaviour
{
    [Header("Villagers in Scene :")]
    [SerializeField] private List<GameObject> _villagersInScene = new List<GameObject>();
    [SerializeField] private List<GameObject> _PickersInScene = new List<GameObject>();
    [SerializeField] private List<GameObject> _WoodsmanInScene = new List<GameObject>();
    [SerializeField] private List<GameObject> _MinersInScene = new List<GameObject>();
    [SerializeField] private List<GameObject> _BuildersInScene = new List<GameObject>();
    [SerializeField] private List<GameObject> _ItinerantsInScene = new List<GameObject>();


    private void CountVillagers()
    {
        //Mettre à jour les listes de villageois en fonction de leur type
    }

}
