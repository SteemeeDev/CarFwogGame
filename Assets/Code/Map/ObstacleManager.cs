using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
            obstacle.transform.position = new Vector3(0, 30 * i);
        }
    }
}
