using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform car;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, car.position + new Vector3(0, 0, transform.position.z), speed * Time.deltaTime);
    }
}
