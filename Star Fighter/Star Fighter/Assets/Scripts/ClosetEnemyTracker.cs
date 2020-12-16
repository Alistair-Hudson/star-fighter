using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetEnemyTracker : MonoBehaviour
{
    [SerializeField] RawImage offScreenTarget;
    [SerializeField] RawImage onScreenTarget;

    EnemyAI target;
    FlightController player;
    float offScreenAngle;

    private void Start()
    {
        player = FindObjectOfType<FlightController>();
        offScreenAngle = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            target = GetClosestEnemy();
        }

        float angleY = GetAngleAroundY();
        float angleX = GetAngleAroundX();
        float angleZ = GetAngleAroundZ();
        SetTargeting(angleY, angleX);
        SetOnScreenTarget(angleZ);

        if (0 > angleY)
        {
            offScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 100);
        }
        else
        {
            offScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 100);
        }

        if (0 > angleX)
        {
            offScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 100);
        }
        else
        {
            offScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 100);
        }

    }

    private void SetOnScreenTarget(float angleZ)
    {
        onScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 100);
        onScreenTarget.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 100);
    }

    private void SetTargeting(float angleY, float angleX)
    {
        if (offScreenAngle <= angleY || -offScreenAngle >= angleY ||
            offScreenAngle <= angleX || -offScreenAngle >= angleX)
        {
            offScreenTarget.enabled = true;
            onScreenTarget.enabled = false;
        }
        else
        {
            offScreenTarget.enabled = false;
            onScreenTarget.enabled = true;
        }
    }

    private float GetAngleAroundY()
    {
        Vector3 targetdir = target.transform.position - player.transform.position;
        Vector3 forward = player.transform.forward;
        return Vector3.SignedAngle(targetdir, forward, Vector3.up);
        
    }

    private float GetAngleAroundX()
    {
        Vector3 targetdir = target.transform.position - player.transform.position;
        Vector3 forward = player.transform.forward;
        return Vector3.SignedAngle(targetdir, forward, Vector3.right);

    }

    private float GetAngleAroundZ()
    {
        Vector3 targetdir = target.transform.position - player.transform.position;
        Vector3 right = player.transform.right;
        return Vector3.SignedAngle(targetdir, right, Vector3.forward);

    }

    private EnemyAI GetClosestEnemy()
    {
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
        EnemyAI target = enemies[0];

        foreach (EnemyAI enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, player.transform.position) < 
                Vector3.Distance(target.transform.position, player.transform.position))
            {
                target = enemy;
            }
        }

        return target;
    }
}
