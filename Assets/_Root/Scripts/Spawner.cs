using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingObjectPrefab;

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
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
    }
}