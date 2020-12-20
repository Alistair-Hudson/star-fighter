using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int gatePoints = 100;
    int score = 0;
    int warpRuns = 0;

    private void Awake()
    {
        if (FindObjectsOfType<Score>().Length > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int points)
    {
        score += points;
    }

    public void EnterWarpGate()
    {
        ++warpRuns;
        AddToScore(gatePoints * warpRuns);

    }
    
    public int GetWarpRuns()
    {
        return warpRuns;
    }
}
