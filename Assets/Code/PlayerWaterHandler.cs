using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterHandler : MonoBehaviour
{
    [SerializeField] ContinuosCarController carController;
    [SerializeField] MenuDeath menuDeath;

    [SerializeField] bool onWater;
    [SerializeField] float minSpeedOnWater;
    [SerializeField] ParticleSystem bubbleParticles;

    [SerializeField] LayerMask waterLayer;
    [SerializeField] float gracePeriod = 1f;

    Animator animator;
    float timeOnWater = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        onWater = Physics2D.OverlapPoint(transform.position, waterLayer);

        //Check if on water and speed is 0
        if (onWater)
        {
            timeOnWater += Time.deltaTime;

            if (carController.rb.velocity.magnitude > minSpeedOnWater)
            {
                if (!bubbleParticles.isPlaying)
                    bubbleParticles.Play();
            }
            else
            {
                if (timeOnWater > gracePeriod)
                {
                    menuDeath.playerdeath();
                    if (bubbleParticles.isPlaying)
                        bubbleParticles.Stop();
                    animator.SetTrigger("DrownFrog");
                    enabled = false;
                }
            }
        }
        else
        {
            timeOnWater = 0f;

            if (bubbleParticles.isPlaying)
                bubbleParticles.Stop();
        }
    }

}

