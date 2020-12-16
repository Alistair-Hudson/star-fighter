using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathDisplay : MonoBehaviour
{
    Text healthDisplay;
    HealthHandler health;

    // Start is called before the first frame update
    void Start()
    {
        healthDisplay = GetComponent<Text>();
        health = FindObjectOfType<FlightController>().GetComponent<HealthHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.GetHealth().ToString();
    }
}
