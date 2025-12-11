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

    [SerializeField] List<Transform> _schoolsWaypoints;
    public List<Transform> SchoolWaypoints => _schoolsWaypoints;

    [SerializeField] List<Transform> _newBuildings; 
    public List<Transform > NewBuildings => _newBuildings;  

    [SerializeField] GameObject _containerZonesInScene;

    [SerializeField] Dictionary<int, Transform> _workZones= new Dictionary<int, Transform>(){};
    public Dictionary<int, Transform> WorkZones => _workZones;

    private void Awake()
    {
        Instance = this;

        _workZones.Add(1, _containerZonesInScene.GetComponentInChildren<FoodZone>().transform);
        _workZones.Add(2, _containerZonesInScene.GetComponentInChildren<Forest>().transform);
        _workZones.Add(3, _containerZonesInScene.GetComponentInChildren<StoneZone>().transform);
    }
}
