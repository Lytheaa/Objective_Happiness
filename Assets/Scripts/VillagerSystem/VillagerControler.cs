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

    private Transform _target;

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wanderingWaypoints = _placesManager.WanderingWaypoints;

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

    public void SetWayPoints()
    {

    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    _target = other.transform;
    //}
}
