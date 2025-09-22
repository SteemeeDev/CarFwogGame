using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathZoneManager : MonoBehaviour
{
    [SerializeField] AnimationCurve wallSpeed;
    [SerializeField] MenuDeath deathManager;

    private void Update()
    {
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
