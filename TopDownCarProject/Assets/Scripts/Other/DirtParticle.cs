using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] dirtParticles;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speedThreshold = 0.2f;

    private void Update()
    {
        if (rb.velocity.magnitude > speedThreshold)
        {
            foreach (var particle in dirtParticles)
            {
                particle.enableEmission = true;
            }
        }
        else
        {
            foreach (var particle in dirtParticles)
            {
                particle.enableEmission = false;
            }
        }
    }
}