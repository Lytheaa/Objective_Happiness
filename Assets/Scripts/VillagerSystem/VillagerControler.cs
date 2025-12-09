using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VillagerControler : MonoBehaviour
{
    private VillagerMovementsManager _villagerMovementsManager;
    private NavMeshAgent _navMeshAgent;
    private List<Transform> _wanderingWaypoints;
    ///Tableau des points de déplacement possibles pour les villageois :
    ///
    private Transform _target;

    int _currentIndex = 0;



    private void Awake()
    {
        _villagerMovementsManager = VillagerMovementsManager.Instance;
        _navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        _wanderingWaypoints = _villagerMovementsManager.WanderingWaypoints;
        ///TEST ERRANCE : 
        //_currentIndex = Random.Range(0, _wanderingWaypoints.Count-1);
        _navMeshAgent.SetDestination(_wanderingWaypoints[0].position);


    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance < .5f && !_navMeshAgent.pathPending) //Remainig distance : longueur restante à parcourir avant d'arriver à destination 
        {
            if (_currentIndex != _wanderingWaypoints.Count - 1)
            { _currentIndex++; }
            else
            { _currentIndex = 0; }  

            _navMeshAgent.SetDestination(_wanderingWaypoints[_currentIndex].position);

            // _currentIndex = Random.Range(0, _wanderingWaypoints.Count-1);
            //_navMeshAgent.SetDestination(_wanderingWaypoints[_currentIndex].position);

        }

        //if (_target != null)
        //{
        //    _navMeshAgent.SetDestination(_target.position);
        //}
    }

    public void SetWayPoints()
    {

    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    _target = other.transform;
    //}
}
