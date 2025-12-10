using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VillagerControler : MonoBehaviour
{
    private PlacesManager _placesManager;
    private NavMeshAgent _navMeshAgent;

    private List<Transform> _wanderingWaypoints;
    private List<Transform> _housesWaypoints;
    private List<Transform> _workZonesWaypoints;


    private Transform _target;

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wanderingWaypoints = _placesManager.WanderingWaypoints;
        _housesWaypoints = _placesManager.HousesWayPoints;
        _workZonesWaypoints = _placesManager.WorkZonesWaypoints;

    }

    private void Start()
    {
    }

    private void Update()
    {
        WanderingMovement();
    }

    public void WanderingMovement() //Random movement between waypoints
    {
        int _currentIndex;
        if (_navMeshAgent.remainingDistance < .5f && !_navMeshAgent.pathPending) //Remainig distance : longueur restante à parcourir avant d'arriver à destination 
        {
            _currentIndex = Random.Range(0, _wanderingWaypoints.Count);
            _navMeshAgent.SetDestination(_wanderingWaypoints[_currentIndex].position);
        }
    }

    public void GoToSleep()
    {
        int houseIndex = 0;

        foreach (Transform houses in _housesWaypoints)
        {
            //if (houseIndex != _housesWaypoints.Count)
            //{
            //    houseIndex++;
            //}
            //else
            //{
            //    houseIndex = 0;
            //}

            if (!houses.GetComponent<House>().IsOccupied)
            {
                _navMeshAgent.SetDestination(_housesWaypoints[houseIndex].position);
            }
        }
    }


    public void GotoWork(int work) /// MODIF
    {
        foreach (Transform zone in _workZonesWaypoints)
        {
            switch (work)
            {
                case 1: //Picker
                    _target = zone.GetComponent<FoodZone>().transform;
                    break;
                case 2: //Woodsman
                    _target = zone.GetComponent<Forest>().transform;
                    break;
                case 3: //Miner
                    _target = zone.GetComponent<StoneZone>().transform;
                    break;
                case 4:
                    Debug.Log($"Zone work target = maçon");
                    break;
            }

            _navMeshAgent.SetDestination(_target.position);
        }
    }

    //public void GoToWork()
    //    {
    //    _navMeshAgent.SetDestination(_target.position);
    //}

    //public Transform SetTargetWork(int work)
    //{
    //    foreach (Transform zone in _workZonesWaypoints)
    //    {
    //        switch (work)
    //        {
    //            case 1: //Picker
    //                _target = zone.GetComponent<FoodZone>().transform; 
    //                break;
    //            case 2: //Woodsman
    //                _target = zone.GetComponent<Forest>().transform;
    //                break;
    //            case 3: //Miner
    //                _target = zone.GetComponent<StoneZone>().transform;
    //                break;
    //            case 4:
    //                Debug.Log($"Zone work target = maçon");
    //                break;
    //        }

    //    return _target;
    //    }
    //}


    //private void OnTriggerEnter(Collider other)
    //{
    //    _target = other.transform;
    //}
}
