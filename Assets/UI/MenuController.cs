using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private bool active;
    private GameObject player;
    private GameObject camSwitcher;

    private void Awake()
    {
        active = true;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<NonPhysicMovement>().movementAllowed = false;
        camSwitcher = GameObject.FindGameObjectWithTag("CameraController");
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetButton("Submit"))
        {
            activation(false);
        } 

        if (!active && Input.GetButton("Cancel"))
        {
            activation(true);
        }

        if (active && Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

    void activation(bool activate)
    {
        player.GetComponent<NonPhysicMovement>().movementAllowed = !activate;
        camSwitcher.GetComponent<CameraSwitch>().SwitchCamera();
        transform.GetChild(0).gameObject.SetActive(activate);
        active = activate;
    }
}
