using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesManager : MonoBehaviour
{
    public static PlacesManager Instance;

    [Header("Containers in scene for waypoints")]
    [SerializeField] GameObject _wanderingWaypointsContainerInScene; 
    [SerializeField] GameObject _containerZonesInScene;

    [SerializeField] List<Transform> _wanderingWaypoints; //Errane par d�faut
    public List<Transform> WanderingWaypoints => _wanderingWaypoints;

    [SerializeField] List<Transform> _housesWayPoints; // Maisons des villageois 
    public List<Transform> HousesWayPoints => _housesWayPoints;

    [SerializeField] List<Transform> _schoolsWaypoints;
    public List<Transform> SchoolWaypoints => _schoolsWaypoints;

    [SerializeField] List<Transform> _newBuildings; 
    public List<Transform > NewBuildings => _newBuildings;  

    [SerializeField] Dictionary<int, Transform> _workZones= new Dictionary<int, Transform>(){};
    public Dictionary<int, Transform> WorkZones => _workZones;

    private void Awake()
    {
        Instance = this;

        _workZones.Add(1, _containerZonesInScene.GetComponentInChildren<FoodZone>().transform);
        _workZones.Add(2, _containerZonesInScene.GetComponentInChildren<WoodZone>().transform);
        _workZones.Add(3, _containerZonesInScene.GetComponentInChildren<StoneZone>().transform);

        foreach (Transform wanderingWaypoint in _wanderingWaypointsContainerInScene.transform)
        {
            _wanderingWaypoints.Add(wanderingWaypoint.GetComponentInChildren<Transform>());
        }
    }
}
