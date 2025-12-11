using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VillagerControler : MonoBehaviour
{
    private PlacesManager _placesManager;
    private NavMeshAgent _navMeshAgent;
    private Villager _villager;

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
        _villager = GetComponent<Villager>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        WanderingMovement();
    }

    public void GoToWork()
    {
        _navMeshAgent.SetDestination(_villager.Data.WorkTarget.position);
    }

    public void WanderingMovement() //Random movement between waypoints
    {
        int _currentIndex;
        if (_navMeshAgent.remainingDistance < .5f && !_navMeshAgent.pathPending) //Remainig distance : longueur restante à parcourir avant d'arriver à destination 
        {
            _currentIndex = Random.Range(0, _placesManager.WanderingWaypoints.Count);
            _navMeshAgent.SetDestination(_placesManager.WanderingWaypoints[_currentIndex].position);
        }
    }

    public void GoToSleep()
    {
        int houseIndex = 0;

        foreach (Transform houses in _placesManager.HousesWayPoints)
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
                _navMeshAgent.SetDestination(_placesManager.HousesWayPoints[houseIndex].position);
            }
        }
    }


}
