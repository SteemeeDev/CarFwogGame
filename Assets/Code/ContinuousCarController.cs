using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ContinuosCarController : MonoBehaviour
{
    const int forward = 1;
    const int backward = 0;

    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float turnSpeed;
    float speed = 0f;
    float drag = 5;

    Rigidbody2D rb;

    public Vector2 velocity = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool accelerating = Input.GetKey("joystick button " + forward);
        bool deccelerating = Input.GetKey("joystick button " + backward);
        bool driting = Input.GetKey("joystick button 7");

        rb.drag = drag;

        transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime));

        if (accelerating == deccelerating)
        {
            speed -= acceleration * Time.deltaTime * 3f;
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
                speed -= acceleration * Time.deltaTime * 10f;
            }
        }

        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        if (!driting)
        {
            velocity = transform.up * speed;
        }
        else { 
            velocity = Vector2.Lerp(new Vector2(0, 1), transform.up, 0.8f) * speed;
        }

        rb.AddForce(velocity, ForceMode2D.Force);

        // Make sure the player doesnt leave the map
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -42f, 42), transform.position.y);
    }
}
