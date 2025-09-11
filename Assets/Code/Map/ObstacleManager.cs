using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject[] mapPartPrefabs;
    [SerializeField] Transform playerTransform;
    [SerializeField] List<GameObject> mapParts;

    private void Start()
    {
        for (int i = 1; i < 15; i++)
        {
            SpawnNewMapPart();
        }
    }
    
    private void FixedUpdate()
    {
        for (int i = 0; i < mapParts.Count - 1; i++)
        {
            if (mapParts[i].transform.position.y < playerTransform.position.y - 60)
            {
                Destroy(mapParts[i]);
                mapParts.Remove(mapParts[i]);
                SpawnNewMapPart();
            }
        }
    }

    private void SpawnNewMapPart()
    {
        GameObject obstacle = Instantiate(mapPartPrefabs[Random.Range(0, mapPartPrefabs.Length)]);
        MapPart mapPart = obstacle.GetComponent<MapPart>();
        MapPart previousMapPart = mapParts.ElementAt(mapParts.Count - 1).GetComponent<MapPart>();
        mapPart.UpdateSpriteSize();
        obstacle.transform.position = new Vector3(0,
            mapParts.ElementAt(mapParts.Count - 1).transform.position.y + previousMapPart.spriteSize.y / 2f + mapPart.spriteSize.y / 2f);
        mapParts.Add(obstacle);
    }
}
