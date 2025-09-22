using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathZoneManager : MonoBehaviour
{
    [SerializeField] AnimationCurve wallSpeed;
    [SerializeField] MenuDeath deathManager;
    [SerializeField] Transform playerTransform;
    [SerializeField] float minDistanceFromPlayer = 5f;

    private void Update()
    {
        if (transform.position.y < playerTransform.position.y - minDistanceFromPlayer)
        {
            transform.position = new Vector2(transform.position.x, playerTransform.position.y - minDistanceFromPlayer);
        }
        transform.position += Vector3.up * wallSpeed.Evaluate(Time.timeSinceLevelLoad) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deathManager.playerdeath();
        }
    }
}
