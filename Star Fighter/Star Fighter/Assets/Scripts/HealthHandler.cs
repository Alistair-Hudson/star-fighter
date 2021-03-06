﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] protected float health = 100;

    public virtual void ReduceHealth(float damage)
    {
        health -= damage;
        if(0 >= health)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(float repair)
    {
        health += repair;
    }

    public float GetHealth()
    {
        return health;
    }


}

