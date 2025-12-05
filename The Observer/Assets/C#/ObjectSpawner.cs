using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Target Item Prefab")]
    public GameObject targetPrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("error");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform randomPoint = spawnPoints[randomIndex];

        Instantiate(targetPrefab, randomPoint.position, randomPoint.rotation);
    }
}