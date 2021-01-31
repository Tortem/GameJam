using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AudioClip speech;
    private AudioSource audioSource;
    private bool active;
    private GameObject player;
    private GameObject camSwitcher;

    private void Awake()
    {
        active = true;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.transform.GetChild(0).GetComponent<AudioSource>();
        player.GetComponent<NonPhysicMovement>().movementAllowed = false;
        camSwitcher = GameObject.FindGameObjectWithTag("CameraController");
    }

    private void Start()
    {
        audioSource.PlayOneShot(speech, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetButton("Jump"))
        {
            activation(false);
        } 

        if (!active && Input.GetButton("Cancel"))
        {
            activation(true);
        }

        if (active && Input.GetButton("Quit"))
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
