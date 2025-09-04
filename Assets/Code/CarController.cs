using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class CarController : MonoBehaviour
{
    const int forward = 1;
    const int backward = 0;

    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float acceleration = 1f;
    float speed = 0f;
    float drag = 5;

    Rigidbody rb;
    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool accelerating = Input.GetKey("joystick button " + forward);
        bool deccelerating = Input.GetKey("joystick button " + backward);
        bool driting = Input.GetKey("joystick button 7");

        rb.drag = drag;

        transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * -180);

        if (accelerating == deccelerating)
        {
            speed -= acceleration * Time.deltaTime;
        }
        else
        {
            if (accelerating)
            {
                Debug.Log("ACCELERATING!");
                speed += acceleration * Time.deltaTime;
                if(driting)
                {
                   // speed += acceleration/2 * Time.deltaTime;
                    rb.drag = drag / 2;
                }
            }

            else if (deccelerating)
            {
                Debug.Log("DECCELERATING!");
                speed -= acceleration * Time.deltaTime * 3;
            }
        }

        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        if (!driting)
        {
            velocity = transform.up * speed;
        }
        else { 
            velocity = Vector3.Lerp(new Vector3(0, 1, 0), transform.up, 0.8f) * speed;
        }

        rb.AddForce(velocity, ForceMode.Acceleration);

        //Debug.Log(rb.velocity.magnitude);
    }
}
