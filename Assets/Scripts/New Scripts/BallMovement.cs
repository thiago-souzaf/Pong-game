using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float acceleration = 0.1f;
    public Vector3 ForceDirection;
    private Vector3 velocity;
    public float speed;

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
        speed += acceleration;
        SetVelocitySpeed();

    }

    private void SetVelocitySpeed()
    {
        velocity = rb.velocity;
        velocity.Normalize();
        velocity *= speed;
        rb.velocity = velocity;
    }
}
