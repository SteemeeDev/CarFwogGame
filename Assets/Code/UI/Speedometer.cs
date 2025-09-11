using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] GameObject frogcar;
    ContinuosCarController car;
    // Start is called before the first frame update
    void Start()
    {
        car = frogcar.GetComponent<ContinuosCarController>();
    }

    // Update is called once per frame
    void Update()
    {

        //float velocity = -(rb.velocity.magnitude*scaling)+startposition;
        //this.gameObject.GetComponent<TMP_Text>().text = velocity.ToString();
        // transform.rotation = Quaternion.Euler(Vector3.forward * velocity);
       
        transform.eulerAngles = new Vector3 (0, 0, Mathf.Lerp(180, 0, car.speed / car.maxSpeed));
    }
}
