using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    private Transform _villagerSpawner;
    private GameManager _gameManager;

    [Header("Spawner Settings :")]
    [SerializeField] private float _areaWidth;
    [SerializeField] private float _areaLenght;
    [SerializeField] private float _areaHeight = 1f;
    [SerializeField] private GameObject _villagerPrefab;
    [SerializeField] private Transform _villagersContainerInScene;

    [Header("Gizmos appearance :")]
    [SerializeField] private Color _gizmosColor = Color.red;
    [SerializeField] private bool _drawGizmos = false;


    private void Awake()
    {
        _villagerSpawner = this.transform;
        _villagerSpawner.position = new Vector3(_villagerSpawner.position.x, _villagerSpawner.position.y + 1, _villagerSpawner.position.z);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // A optimiser plus tard
    }

    // Update is called once per frame
    void Update()
    {
        //KeySpawnTest();
    }

    public void SpawnVillager(int numberOfVillagers)
    {
        Vector3 areaSpawnPosition = _villagerSpawner.position;

        float minX = areaSpawnPosition.x - _areaWidth * .5f;
        float maxX = areaSpawnPosition.x + _areaWidth * .5f;

        float minZ = areaSpawnPosition.z - _areaLenght * .5f;
        float maxZ = areaSpawnPosition.z + _areaLenght * .5f;

        for (int i = 0; i < numberOfVillagers; i++)
        {
            Vector3 spawnPosition = Vector3.zero;
            spawnPosition.x = Random.Range(minX, maxX);
            spawnPosition.z = Random.Range(minZ, maxZ);
            spawnPosition.y = areaSpawnPosition.y;

            //Instancier le villageois dans le GameObject "VillagersList"
            Instantiate(_villagerPrefab, spawnPosition, Quaternion.identity, _villagersContainerInScene.transform); //Verifier rotation des sprites 2D

            _gameManager.NumberOfVillagers++; // Ajouter au compteur de villageois total dans GameManager ? 

            //Ajouter le villageois à la liste des villageois dans VillagersList ?
        }

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

    //private void KeySpawnTest()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        Debug.Log("Spawn Villager");
    //        //SpawnVillager();
    //    }
    //}
}
