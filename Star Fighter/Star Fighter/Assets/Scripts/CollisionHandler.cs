using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        HealthHandler health = GetComponentInParent<HealthHandler>();
        health.ReduceHealth(health.GetHealth());
    }

    private void OnParticleCollision(GameObject other)
    {
        print(gameObject + "hit by particles");
    }
}
