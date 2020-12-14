using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void ReduceHealth(int damage)
    {
        health -= damage;
        if (0 >= health)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(int repair)
    {
        health += repair;
    }

    public int GetHealth()
    {
        return health;
    }


}
