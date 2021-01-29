using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 100;
    Vector2 velocity;
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rigidbody.AddForce(new Vector3(velocity.x, velocity.y, 0));
        //transform.Translate(velocity.x, 0, velocity.y);
    }
}
