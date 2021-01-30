using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private Camera playerCam;
    private Camera extCam;

    private void Awake()
    {
        playerCam = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.GetComponent<Camera>();
        extCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerCam.enabled = false;
        extCam.enabled = true;
    }

    public void SwitchCamera()
    {
        playerCam.enabled = !playerCam.enabled;
        extCam.enabled = !extCam.enabled;
    }
}
