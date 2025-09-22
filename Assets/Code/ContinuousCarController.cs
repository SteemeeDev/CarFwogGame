using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ContinuosCarController : MonoBehaviour
{
    const int forward = 1;
    const int backward = 0;

    public float maxSpeed = 10f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float turnSpeed;
    public float speed = 0f;
    float drag = 5;

    public Rigidbody2D rb;

    public Vector2 velocity = Vector2.zero;

    [SerializeField] float threshold = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
        {
            Debug.Log("TURNING");
            transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime));
        }
    }

    private void FixedUpdate()
    {
        bool accelerating = Input.GetKey("joystick button " + forward) || Input.GetKey(KeyCode.UpArrow);
        bool deccelerating = Input.GetKey("joystick button " + backward) || Input.GetKey(KeyCode.DownArrow);
        //  bool driting = Input.GetKey("joystick button 7");

        //   Debug.Log(Input.GetAxis("Horizontal"));

        if (accelerating == deccelerating)
        {
            speed -= acceleration * Time.deltaTime * 3f;
        }
        else
        {
            if (accelerating)
            {
               // Debug.Log("ACCELERATING!");
                speed += acceleration * Time.deltaTime;
            }

            else if (deccelerating)
            {
               // Debug.Log("DECCELERATING!");
                speed -= acceleration * Time.deltaTime * 10f;
            }
        }

        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        velocity = transform.up * speed;

        rb.AddForce(velocity);

        if (rb.velocity.magnitude > threshold) Debug.Log("RIGIDBODY MOVED TOO FAST! Moved: " + rb.velocity.magnitude);

        // Make sure the player doesnt leave the map
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -32f, 32), transform.position.y);
    }
}
