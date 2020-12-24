using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyAI[] enemyPrefabs;
    [SerializeField] int initialSpawnNum = 5;
    [SerializeField] int difficultyLevel = 1;
    [SerializeField] float spawnDelay = 20f;

    [SerializeField] float maxAreaSize = 500f;
    [SerializeField] int maxNumEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = FindObjectOfType<Score>().GetWarpRuns();
        initialSpawnNum *= (FindObjectOfType<Score>().GetWarpRuns() + 1);
        maxNumEnemies *= (FindObjectOfType<Score>().GetWarpRuns() + 1);
        spawnDelay /= (FindObjectOfType<Score>().GetWarpRuns() + 1);

        SpawnInitialEnemies();
        StartCoroutine(SpawningLoop());
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
        int spawnRange = difficultyLevel <= enemyPrefabs.Length ? difficultyLevel : enemyPrefabs.Length;
        EnemyAI enemy = Instantiate(enemyPrefabs[Random.Range(0, spawnRange)],
                                                new Vector3(Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize)),
                                                Quaternion.identity);
        enemy.transform.SetParent(transform);
        

        --maxNumEnemies;
    }

    IEnumerator SpawningLoop()
    {
        while (0 <= maxNumEnemies)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
