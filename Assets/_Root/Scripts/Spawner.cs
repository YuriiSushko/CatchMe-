using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public GameObject prefab;
    public int weight = 1;
}


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<SpawnEntry> spawnObjects = new List<SpawnEntry>();

    [SerializeField]
    private float spawnInterval = 1f;

    [SerializeField]
    private float minX = -2.2f;

    [SerializeField]
    private float maxX = 2.2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        GameObject prefabToSpawn = GetRandomPrefabByWeight();

        if (prefabToSpawn == null)
        {
            return;
        }

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomPrefabByWeight()
    {
        int totalWeight = 0;

        foreach (var entry in spawnObjects)
        {
            if (entry.prefab != null && entry.weight > 0)
            {
                totalWeight += entry.weight;
            }
        }

        if (totalWeight == 0)
        {
            return null;
        }

        int randomValue = Random.Range(0, totalWeight);

        foreach (var entry in spawnObjects)
        {
            if (entry.prefab == null || entry.weight <= 0)
            {
                continue;
            }

            randomValue -= entry.weight;

            if (randomValue < 0)
            {
                return entry.prefab;
            }
        }

        return null;
    }
}