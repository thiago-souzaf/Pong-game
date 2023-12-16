using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float acceleration = 0.1f;
    private Vector3 velocity;
    private float initialSpeed = 5f;
    private float speed;

    private float minDirection = 0.5f;

    public bool isMoving;

    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoving = false;
        startPosition = transform.position;
    }

    private void ThrowBall()
    {

        speed = initialSpeed;
        rb.velocity = ChooseRandomDirection() * speed;
        isMoving = true;

    }

    private Vector3 ChooseRandomDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        Vector3 direction = new(0.5f * signX, 0, 0.5f * signZ);
        return direction.normalized;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            ThrowBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Increases speed everytime it collides with something
        speed += acceleration;
        
        // New direction depends on where the player hit the ball
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

    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        isMoving = false;
        transform.position = startPosition;
    }
}
