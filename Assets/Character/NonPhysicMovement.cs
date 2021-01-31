using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class NonPhysicMovement : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip jump;
    public AudioClip land;

    private CharacterController controller;
    private Vector3 playerVelocity = Vector3.zero;
    private int airCounter = 0;
    [SerializeField] private int airTime = 100;
    [SerializeField] private float playerSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 0.7f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool movementAllowed = true;

    private void Awake()
    {
        audioSource = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementAllowed) { return; }

        isGrounded = controller.isGrounded;

        // movement
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        controller.Move(move * Time.deltaTime *  playerSpeed + playerVelocity * Time.deltaTime);

        if (!isGrounded)
        {
            airCounter++;
        }

        // jumping and gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            if (airCounter > airTime)
            {
                audioSource.PlayOneShot(land, 0.2f);
            }
            airCounter = 0;
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioSource.PlayOneShot(jump, 0.5f);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
