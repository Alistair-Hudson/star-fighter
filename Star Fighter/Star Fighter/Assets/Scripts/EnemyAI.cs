using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] float rotationalSpeead = 1f;
    [SerializeField] float maxEngagmentDistance = 20f;
    [SerializeField] GameObject[] guns;

    FlightController target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<FlightController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            RotateToTarget();
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            ProcessShoot();
        }
    }

    private void ProcessShoot()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= maxEngagmentDistance)
        {
            SetGunState(true);
        }
        else
        {
            SetGunState(false);
        }
    }

    private void SetGunState(bool state)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }

    void RotateToTarget()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.transform.position - transform.position;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, 
                                                        targetDirection, 
                                                        rotationalSpeead*Time.deltaTime, 
                                                        0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
