using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    HealthHandler health;
    
    private void Start()
    {
        health = GetComponentInParent<HealthHandler>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        health.ReduceHealth(health.GetHealth());
    }

    private void OnParticleCollision(GameObject other)
    {
        health.ReduceHealth(10);
    }
}
