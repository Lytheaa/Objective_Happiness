using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovementsManager : MonoBehaviour
{
    public static VillagerMovementsManager Instance;
    [SerializeField] List<Transform> _wanderingWaypoints;
    public List<Transform> WanderingWaypoints => _wanderingWaypoints;

    private void Awake()
    {
            Instance = this;
    }
}
