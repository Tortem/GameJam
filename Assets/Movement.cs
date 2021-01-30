using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public float gravity = 1.0f;
    public float maxVelocityChange = 1.0f;
    public bool canJump = true;
    public float jumpHeight = 1.0f;
    public bool isGrounded = false;
    private Rigidbody rigid;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;
        rigid.useGravity = false;
        
    }

    void FixedUpdate()
    {


        // Calculate how fast we should be moving
        Vector3 targetVelocity;
        if (isGrounded)
        {
            targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        } else
        {
            targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));
        }
        
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= speed;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = rigid.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rigid.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (isGrounded && canJump && Input.GetButton("Jump"))
        {
            rigid.AddForce(Vector3.up * 100);
            //rigid.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
        }

        // We apply gravity manually for more tuning control
        rigid.AddForce(new Vector3(0, -gravity * rigid.mass, 0));
    }

    void LateUpdate()
    {
        float DistanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, DistanceToTheGround + 0.3f);
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
