using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private bool active;

    private void Awake()
    {
        active = true;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<NonPhysicMovement>().movementAllowed = !activate;
        transform.GetChild(0).gameObject.SetActive(activate);
        active = activate;
    }
}
