using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class NonPhysicMovement : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip jump;
    public AudioClip land;

    private bool jumped;
    private CharacterController controller;
    private Vector3 playerVelocity = Vector3.zero;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float playerSprintSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool movementAllowed = false;

    private void Awake()
    {
        audioSource = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        movementAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementAllowed) { return; }

        float speed;
        if (Input.GetButton("Sprint")) { speed = playerSprintSpeed; }
        else { speed = playerSpeed; }

        isGrounded = controller.isGrounded;

        // movement
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        controller.Move(move * Time.deltaTime *  speed + playerVelocity * Time.deltaTime);

        if (!isGrounded)
        {
            jumped = true;
        }

        // jumping and gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            if (jumped)
            {
                audioSource.PlayOneShot(land);
                jumped = false;
            }
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioSource.PlayOneShot(jump);
            jumped = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
