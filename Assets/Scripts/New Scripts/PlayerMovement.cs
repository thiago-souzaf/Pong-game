using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESide
{
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float inputDir;
    private string inputString;
    private Rigidbody rb;

    [SerializeField] private ESide playerSide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputString = playerSide == ESide.Left ? "PlayerLeft" : "PlayerRight";
    }

    void FixedUpdate()
    {
        inputDir = Input.GetAxisRaw(inputString);
        rb.velocity = inputDir * movementSpeed * Vector3.forward;
    }
}
