using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform playerTransform;
    [SerializeField] List<GameObject> obstacles;

    private void Start()
    {
        for (int i = 1; i < 15; i++)
        {
            SpawnNewMapPart();
        }
    }
    
    private void FixedUpdate()
    {
        for (int i = 0; i < obstacles.Count - 1; i++)
        {
            if (obstacles[i].transform.position.y < playerTransform.position.y - 60)
            {
                Destroy(obstacles[i]);
                obstacles.Remove(obstacles[i]);
                SpawnNewMapPart();
            }
        }
    }

    private void SpawnNewMapPart()
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
        MapPart mapPart = obstacle.GetComponent<MapPart>();
        MapPart previousMapPart = obstacles.ElementAt(obstacles.Count - 1).GetComponent<MapPart>();
        mapPart.UpdateSpriteSize();
        obstacle.transform.position = new Vector3(0,
            obstacles.ElementAt(obstacles.Count - 1).transform.position.y + previousMapPart.spriteSize.y / 2f + mapPart.spriteSize.y / 2f);
        obstacles.Add(obstacle);
    }
}
