using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGateSpawner : MonoBehaviour
{
    [SerializeField] WarpGate warpgatePrefab;
    [SerializeField] float baseTime = 60;
    [SerializeField] float maxAreaSize = 500f;

    private IEnumerator Start()
    {
        float spawnDelay = (FindObjectOfType<Score>().GetWarpRuns() + 1) * baseTime;
        yield return new WaitForSeconds(spawnDelay);
        WarpGate warpGate = Instantiate(warpgatePrefab,
                                        new Vector3(Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize),
                                                            Random.Range(-maxAreaSize, maxAreaSize)),
                                        Quaternion.identity);
        warpGate.transform.parent = gameObject.transform;
    }
}
