using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyAI[] enemyPreabs;
    [SerializeField] int initialSpawnNum = 5;
    [SerializeField] int difficultyLevel = 0;

    [SerializeField] float maxAreaSize = 500f;
    [SerializeField] int maxNumEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialEnemies();
    }

    private void SpawnInitialEnemies()
    {
        for (int i = 0; i < initialSpawnNum; ++i)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (0 >= maxNumEnemies)
        {
            return;
        }

        EnemyAI enemy = Instantiate(enemyPreabs[Random.Range(0, difficultyLevel)],
                                                new Vector3(Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize)),
                                                Quaternion.identity);
        enemy.transform.parent = gameObject.transform;

        --maxNumEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
}
