using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
public class VillagerController : MonoBehaviour
{
    private PlacesManager _placesManager;
    private NavMeshAgent _navMeshAgent;
    private Villager _villager;
    private Transform _target;
    private Coroutine _coroutine;

    private void Awake()
    {
        _placesManager = PlacesManager.Instance;
        _villager = GetComponent<Villager>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_villager.Data.IsBusy)
        {
            if (_navMeshAgent.remainingDistance < .5f /*&& !_navMeshAgent.pathPending*/)
            {
                RaycastHit[] allHits = Physics.SphereCastAll(transform.position, 2, Vector3.down);
                foreach (var hit in allHits)
                {
                    Place place;
                    if (hit.collider.TryGetComponent<Place> (out place))
                    {
                        if (hit.collider.transform == _target)
                        {
                            if(_coroutine == null)
                                _coroutine = StartCoroutine(place.ActionCoroutine(_villager, _coroutine));
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            WanderingMovement();
        }
    }

    public void GoToSchool()
    {
        if (_placesManager.SchoolWaypoints.Count > 0)
        {
            _villager.Data.IsBusy = true; 
            int schoolIndex = Random.Range(0, _placesManager.SchoolWaypoints.Count);
            _target = _placesManager.SchoolWaypoints[schoolIndex];
            _navMeshAgent.SetDestination(_target.position);
            //_navMeshAgent.SetDestination(_placesManager.SchoolWaypoints[schoolIndex].position);
        }
    }

    public void GoToWork()
    {
        if (_villager.Data.IsTired)
            return;

        if (_villager.Data.WorkId < 4) // S'il a un m�tier autre que vagabond ou ma�on 
        {
            _target = _villager.Data.WorkTarget;
            _navMeshAgent.SetDestination(_target.position);
            _villager.Data.IsBusy = true;
            //_navMeshAgent.SetDestination(_villager.Data.WorkTarget.position);
        }
        else if (_villager.Data.WorkId == 4 && _placesManager.NewBuildings.Count > 0) // Si c'est un ma�on, et qu'au moins un b�timent est � construite
        {
            //Debug.Log($"Builder on work");
            int newIndex = Random.Range(0, _placesManager.NewBuildings.Count -1);

            //Debug.Log($"Building index {newIndex}");
            _target = _placesManager.NewBuildings[newIndex];
            //Debug.Log($"Builder : Construction new building {_target}");

            _navMeshAgent.SetDestination(_target.position);
            _villager.Data.IsBusy = true;
            //_navMeshAgent.SetDestination(_placesManager.NewBuildings[newIndex].position);
        }
        else
        {
            WanderingMovement();
        }
    }

    public void WanderingMovement() //Random movement between waypoints
    {
        int currentIndex;
        if (_navMeshAgent.remainingDistance < .5f && !_navMeshAgent.pathPending) //Remainig distance : longueur restante � parcourir avant d'arriver � destination 
        {
            currentIndex = Random.Range(0, _placesManager.WanderingWaypoints.Count);
            _navMeshAgent.SetDestination(_placesManager.WanderingWaypoints[currentIndex].position);
        }
    }

    public void GoToSleep()
    {
        if (!_villager.Data.IsTired)
            return;
        int houseIndex = 0;

        foreach (Transform house in _placesManager.HousesWayPoints)
        {
            print($"{_villager.Data.WorkId}: {house.GetComponent<House>().IsOccupied}");
        }
        
        foreach (Transform house in _placesManager.HousesWayPoints)
        {
            //if (houseIndex != _housesWaypoints.Count)
            //{
            //    houseIndex++;
            //}
            //else
            //{
            //    houseIndex = 0;
            //}

            var houseComponent = house.GetComponent<House>();
            if (!houseComponent.IsOccupied)
            {
                houseComponent.IsOccupied = true;
                _target = _placesManager.HousesWayPoints[houseIndex];
                _navMeshAgent.SetDestination(_target.position);
                _villager.Data.IsBusy = true;
                //_navMeshAgent.SetDestination(_placesManager.HousesWayPoints[houseIndex].position);
                return;
            }
        }
        if(_villager.Data.WorkId == 1) print("no houses left");
    }

}
