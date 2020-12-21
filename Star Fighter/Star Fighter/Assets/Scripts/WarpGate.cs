using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<FlightController>())
        {
            FindObjectOfType<Score>().EnterWarpGate();
            FindObjectOfType<SceneHandler>().LoadPreviousScene();
        }
    }
}
