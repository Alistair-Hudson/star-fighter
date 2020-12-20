using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] float health = 100;

    public void ReduceHealth(float damage)
    {
        health -= damage;
        if(0 >= health)
        {
            if (GetComponent<FlightController>())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            FindObjectOfType<Score>().AddToScore(GetComponent<EnemyAI>().GetPointsValue());
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
