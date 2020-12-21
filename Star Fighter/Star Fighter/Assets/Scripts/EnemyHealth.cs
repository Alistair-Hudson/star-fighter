using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthHandler
{
    public override void ReduceHealth(float damage)
    {
        health -= damage;
        if (0 >= health)
        {
            FindObjectOfType<Score>().AddToScore(GetComponent<EnemyAI>().GetPointsValue());
            Destroy(gameObject);
        }
    }

}
