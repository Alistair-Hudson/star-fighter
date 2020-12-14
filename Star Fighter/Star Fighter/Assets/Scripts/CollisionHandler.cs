using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(gameObject + "hit");
    }

    private void OnParticleCollision(GameObject other)
    {
        print(gameObject + "hit by particles");
    }
}
