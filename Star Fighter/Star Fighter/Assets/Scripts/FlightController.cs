using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class FlightController : MonoBehaviour
{
    [SerializeField] float flightSpeed = 10f;
    [SerializeField] GameObject[] guns;

    
    bool isControlEnabled = true;

    //Constants
    string HORIZONTAL_AXIS = "Horizontal";
    string VERTICAL_AXIS = "Vertical";
    string YAW = "Yaw";
    string SHOOT = "Fire1";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, flightSpeed * Time.deltaTime);
                
        if (isControlEnabled)
        {
            ProcessPitch();
            ProcessRoll();
            ProcessYaw();
            ProcessShoot();
        }
    }

    public void SetControlState(bool state)
    {
        isControlEnabled = state;
    }

    private void ProcessShoot()
    {
        if (CrossPlatformInputManager.GetButton(SHOOT))
        {
            SetGunState(true);
        }
        else
        {
            SetGunState(false);
        }
    }

    private void SetGunState(bool state)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }

    private void ProcessRoll()
    {
        float roll = -CrossPlatformInputManager.GetAxis(HORIZONTAL_AXIS);
        transform.Rotate(0, 0, roll);
    }

    private void ProcessPitch()
    {
        float pitch = CrossPlatformInputManager.GetAxis(VERTICAL_AXIS);
        transform.Rotate(pitch, 0, 0);
    }

    private void ProcessYaw()
    {
        float yaw = CrossPlatformInputManager.GetAxis(YAW);
        transform.Rotate(0, yaw, 0);
    }
}
