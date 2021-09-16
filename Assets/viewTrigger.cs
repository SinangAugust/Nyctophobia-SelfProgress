using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewTrigger : MonoBehaviour
{
    public Camera myCam;
    public Transform target;
    public Transform thePlayer;

    float initialFOV;
    float currentFOV;
    float fovUpSpeed = 4f;
    float fovDownSpeed = 1.5f;

    float maxFOV = 120f;
    float minFOV = 60f;

    bool isTriggered = false;
    bool isReady = false;

    void Start()
    {
        initialFOV = 60f;
    }

    void Update()
    {
        myCam.fieldOfView = initialFOV;
        float distance = (target.transform.position - thePlayer.transform.position).magnitude;

        if (distance <= 8)
        {
            isTriggered = true;
            if (isTriggered == true)
            {
                // --This will increase the field of view
                initialFOV += fovUpSpeed;
                if (maxFOV <= initialFOV)
                {
                    initialFOV = 120f;
                    currentFOV = initialFOV;
                    isReady = true;
                }
            }
        }

        else if (distance >= 12 && isReady == true)
        {
            // --This will revert the field of view back to normal
            initialFOV -= fovDownSpeed;
            if (minFOV >= initialFOV)
            {
                initialFOV = 60f; ;
                isReady = false;
            }
        }
    }

    void ResetFOV()
    {
        initialFOV = 60f;
    }
}
