using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] leftGoingCars;
    [SerializeField] GameObject[] rightGoingCars;
    float time;
    float spawntime = 0.6f;
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
            int type = Random.Range(0, 2);
            if (type == 1)
            {
                Object.Instantiate(leftGoingCars[Random.Range(0, leftGoingCars.Length)], transform.position + new Vector3(40, Random.Range(-21, 21), -1), leftGoingCars[0].transform.rotation);
            } else Object.Instantiate(rightGoingCars[Random.Range(0, rightGoingCars.Length)], transform.position + new Vector3(-40, Random.Range(-21, 21), -1), rightGoingCars[0].transform.rotation);
            time = 0;
        }
            
    }
}
