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

    [SerializeField] List<Transform> _workZonesWaypoints; //Zones de travail, dans l'inspector, à modifier
    public List<Transform> WorkZonesWaypoints => _workZonesWaypoints;

    private void Awake()
    {
            Instance = this;
    }
}
