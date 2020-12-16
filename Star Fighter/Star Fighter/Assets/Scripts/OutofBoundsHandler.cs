using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBoundsHandler : MonoBehaviour
{
    Canvas warningUI;

    private void Start()
    {
        warningUI = FindObjectOfType<OutOFBoundsWarning>().GetComponent<Canvas>();
        warningUI.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        warningUI.enabled = true;
        other.GetComponentInParent<HealthHandler>().ReduceHealth(1f * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        warningUI.enabled = false;
    }
}
