using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VillagerSpawner : MonoBehaviour
{
    private Transform _villagerSpawner;

    [Header("Spawner Settings :")]
    [SerializeField] private float _areaWidth;
    [SerializeField] private float _areaLenght;
    [SerializeField] private float _areaHeight = 1f;
    [SerializeField] private GameObject _villagerPrefab;
    [SerializeField] private Transform _villagersContainerInScene;

    [Header("Gizmos appearance :")]
    [SerializeField] private Color _gizmosColor = Color.red;
    [SerializeField] private bool _drawGizmos = false;

    private bool _firstSpawn = true;

    private void Awake()
    {
        _villagerSpawner = this.transform;
        _villagerSpawner.position = new Vector3(_villagerSpawner.position.x, _villagerSpawner.position.y + 1, _villagerSpawner.position.z);
    }

    public void SpawnVillager(int numberOfVillagers)
    {
        Vector3 areaSpawnPosition = _villagerSpawner.position;

        float minX = areaSpawnPosition.x - _areaWidth * .5f;
        float maxX = areaSpawnPosition.x + _areaWidth * .5f;

        float minZ = areaSpawnPosition.z - _areaLenght * .5f;
        float maxZ = areaSpawnPosition.z + _areaLenght * .5f;

        for (int i = 0 ; i < numberOfVillagers; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), areaSpawnPosition.y, Random.Range(minZ, maxZ));

            GameObject villagerGO = Instantiate(_villagerPrefab, spawnPosition, Quaternion.identity, _villagersContainerInScene.transform); //Verifier rotation des sprites 2D
            Villager villager = villagerGO.GetComponent<Villager>();

            // SET WORK //
            int previousWorkIndex = villager.Data.WorkId;

            int newWorkIndex;
            if (_firstSpawn)
            {
                newWorkIndex = i +1 ; // Assigner un travail unique lors du premier spawn
            }
            else
            {
                newWorkIndex = Random.Range(1, 6); // Assigner un travail aléatoire pour les autres spawns
            }
            villager.Work.SetWork(newWorkIndex);

            VillagerManager.Instance.RegisterVillager(villager);
        }
        _firstSpawn = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmosColor;
        if (_drawGizmos)
        {
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), // Position
            new Vector3(_areaWidth, _areaHeight, _areaLenght)); // Taille
        }
    }
}
