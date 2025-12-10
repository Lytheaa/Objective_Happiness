using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesManager : MonoBehaviour
{
    public static PlacesManager Instance;

    [SerializeField] List<Transform> _wanderingWaypoints; //Errane par défaut
    public List<Transform> WanderingWaypoints => _wanderingWaypoints;

    [SerializeField] List<Transform> _housesWayPoints; // Maisons des villageois 
    public List<Transform> HousesWayPoints => _housesWayPoints;



    private void Awake()
    {
            Instance = this;
    }
}
