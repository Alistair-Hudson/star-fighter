using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetEnemyTracker : MonoBehaviour
{
    EnemyAI target;
    FlightController player;
    float offScreenAngle;
    Camera playerView;
    RectTransform position;

    float TARGETOR_SIZE = 50;

    private void Start()
    {
        player = FindObjectOfType<FlightController>();
        offScreenAngle = Camera.main.fieldOfView;
        playerView = Camera.main;
        position = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            target = GetClosestEnemy();
            return;
        }
        SetTargetLocator();

    }

    private void SetTargetLocator()//needs to be tuned
    {
        Vector2 screenPoint = new Vector2(  playerView.WorldToScreenPoint(target.transform.position).x,
                                            playerView.WorldToScreenPoint(target.transform.position).y);

        screenPoint.x = OffScreenCorrection(GetAngleAroundY(), Screen.width, screenPoint.x);
        screenPoint.y = OffScreenCorrection(GetAngleAroundX(), Screen.height, screenPoint.y);

        position.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, screenPoint.x, TARGETOR_SIZE);
        position.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, screenPoint.y, TARGETOR_SIZE);
    }

    private EnemyAI GetClosestEnemy()
    {
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
        EnemyAI target = enemies[0];
        if (!target)
        {
            GetComponent<Image>().enabled = false;
            return null;
        }
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

    private float OffScreenCorrection(float angle, float screenSize, float currentScreenPoint)
    {
        if (-offScreenAngle >=  angle)
        {
            return 0;
        }
        if (offScreenAngle <= angle)
        {
            return screenSize;
        }
        return currentScreenPoint;

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
}
