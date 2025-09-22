using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] leftGoingCars;
    float time;
    float spawntime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > spawntime)
        {
            Object.Instantiate(leftGoingCars[Random.Range(0, leftGoingCars.Length)], transform.position + new Vector3(40, Random.Range(-30, 30), -1), leftGoingCars[0].transform.rotation);
            time = 0;
            
        }
            
    }
}
