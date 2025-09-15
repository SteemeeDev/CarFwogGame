using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
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
        MapPart previousMapPart = mapParts.ElementAt(mapParts.Count - 1).GetComponent<MapPart>();
        GameObject obstacle = Instantiate(previousMapPart.validMapParts[Random.Range(0, previousMapPart.validMapParts.Length)]);
        MapPart mapPart = obstacle.GetComponent<MapPart>();
        mapPart.UpdateSpriteSize();
        obstacle.transform.position = new Vector2(0,
            mapParts.ElementAt(mapParts.Count - 1).transform.position.y + 64);
        mapParts.Add(obstacle);
    }
}
