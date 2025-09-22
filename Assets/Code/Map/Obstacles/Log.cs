using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - playerTransform.position.y < 30f)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }

        if (transform.position.y < playerTransform.position.y - 60f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Log hit player!");
        }
    }
}
