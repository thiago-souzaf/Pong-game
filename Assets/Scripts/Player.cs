using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayer
{
    Left,
    Right
}
public class Player : MonoBehaviour
{
    public ePlayer player;
    public float speed = 15f;
    private Rigidbody rb;
    public float inputSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player == ePlayer.Left)
        {
            inputSpeed = Input.GetAxisRaw("PlayerLeft");
        } else if (player == ePlayer.Right)
        {
            inputSpeed = Input.GetAxisRaw("PlayerRight");
        }
        if (transform.position.z < 5f && transform.position.z > -5f)
        rb.velocity = Vector3.forward * inputSpeed * speed;
    }
}
