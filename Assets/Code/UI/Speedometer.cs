using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] GameObject frogcar;
    [SerializeField] float scaling;
    [SerializeField] int startposition = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = -(frogcar.GetComponent<Rigidbody2D>().velocity.magnitude*scaling)+startposition;
        //this.gameObject.GetComponent<TMP_Text>().text = velocity.ToString();
        transform.rotation = Quaternion.Euler(Vector3.forward * velocity);
    }
}
