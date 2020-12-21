using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthHandler
{

    public override void ReduceHealth(float damage)
    {
        health -= damage;
        if (0 >= health)
        {
            FindObjectOfType<SceneHandler>().LoadGameOver();
        }
    }

}
