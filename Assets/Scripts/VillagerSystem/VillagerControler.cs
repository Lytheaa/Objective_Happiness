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

    Transform _workTarget;


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

    private void GoToSchool()
    {
        if (_placesManager.SchoolWaypoints.Count > 0)
        {
            int schoolIndex = Random.Range(0, _placesManager.SchoolWaypoints.Count);
            _navMeshAgent.SetDestination(_placesManager.SchoolWaypoints[schoolIndex].position);
        }
    }

    public void GoToWork()
    {
        if (_villager.Data.WorkId < 5)
        {
            if (_villager.Data.WorkId < 4) // S'il a un métier autre que vagabond ou maçon 
            {
                _workTarget = _villager.Data.WorkTarget;
            }
            if (_villager.Data.WorkId == 4 && _placesManager.NewBuildings.Count > 0) // Si c'est un maçon, et qu'au moins un bâtiment est à construite
            {
                int newIndex = Random.Range(0, _placesManager.NewBuildings.Count);
                _workTarget = _placesManager.NewBuildings[newIndex];
            }
            _navMeshAgent.SetDestination(_workTarget.position);
        }
    }

    public void WanderingMovement() //Random movement between waypoints
    {
        int currentIndex;
        if (_navMeshAgent.remainingDistance < .5f && !_navMeshAgent.pathPending) //Remainig distance : longueur restante à parcourir avant d'arriver à destination 
        {
            currentIndex = Random.Range(0, _placesManager.WanderingWaypoints.Count);
            _navMeshAgent.SetDestination(_placesManager.WanderingWaypoints[currentIndex].position);
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
