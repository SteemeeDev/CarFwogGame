using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCarScript : MonoBehaviour
{
    [SerializeField] bool goingleft;
    [SerializeField] float speed = 1;
    float exitlocation = 35;
    // Start is called before the first frame update
    void Start()
    {
        if (goingleft)
        {
            speed = -speed;
            exitlocation = -35;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed, 0, 0);
        if (goingleft)
        {
            if (transform.position.x <= exitlocation)
            Destroy(gameObject);
        } else if (transform.position.x >= exitlocation)
            Destroy(gameObject);


    }

}
