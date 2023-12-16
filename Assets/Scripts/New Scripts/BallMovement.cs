using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float acceleration = 0.1f;
    private Vector3 velocity;
    public float speed;

    private float minDirection = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void ThrowBall()
    {
        rb.AddForce(ChooseRandomDirection());
        SetVelocitySpeed();

    }

    private Vector3 ChooseRandomDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        Vector3 direction = new(0.5f * signX, 0, 0.5f * signZ);
        return direction;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Increases speed everytime it collides with something
        speed += acceleration;
        

        if (collision.gameObject.CompareTag("Player"))
        {
            // Sets a normalized vector that goes from the player to the ball
            Vector3 newDirection = (transform.position - collision.gameObject.transform.position).normalized;

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            rb.velocity = newDirection;
        }
        SetVelocitySpeed();
    }

    private void SetVelocitySpeed()
    {
        // Magnetude of rigidbody's velocity is defined by speed variable
        velocity = rb.velocity;
        velocity.Normalize();
        velocity *= speed;
        rb.velocity = velocity;
    }
}
