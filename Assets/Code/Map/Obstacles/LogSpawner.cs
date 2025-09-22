using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] GameObject logPrefab;

    [SerializeField] int minSpawnAmount = 0;
    [SerializeField] int maxSpawnAmount = 3;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnLogs();
    }

    void SpawnLogs()
    {
        int spawnAmount = Random.Range(minSpawnAmount, maxSpawnAmount + 1);
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject log = Instantiate(logPrefab, transform.position + new Vector3(Random.Range(-25f, 25f), Random.Range(-25f, 25f)), Quaternion.identity);
            log.transform.parent = transform;
        }
    }
}
