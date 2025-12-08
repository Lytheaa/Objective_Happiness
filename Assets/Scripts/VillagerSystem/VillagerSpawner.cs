using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void KeySpawnTest()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Spawn Villager");
        }
    }
}
