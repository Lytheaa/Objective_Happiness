using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VillagerMovement : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    ///Tableau des points de déplacement possibles pour les villageois :
    private Transform _destination;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void SetDestination(Transform destination)
    {
        if (destination != null)
        {

        }
    }
}
