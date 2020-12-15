using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBoundsHandler : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        other.GetComponentInParent<HealthHandler>().ReduceHealth(1f * Time.deltaTime);
    }
}
