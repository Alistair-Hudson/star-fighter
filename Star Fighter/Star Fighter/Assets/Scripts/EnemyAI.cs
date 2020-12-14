using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] float maxEngagmentDistance = 20f;
    [SerializeField] GameObject[] guns;

    PlayerHealth target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(0, 0, enemySpeed*Time.deltaTime);
        ProcessShoot();
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
}
