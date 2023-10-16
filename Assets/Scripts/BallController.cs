using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float speed;
    public float minDirection = 0.5f;
    public float acceleration;
    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = true;

    private GameController gameController;

    public GameObject downBorder;
    public GameObject upBorder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (stopped) return;

        
        if(this.transform.position.z < upBorder.transform.position.z || this.transform.position.z > downBorder.transform.position.z)
        {
            this.rb.MovePosition(this.rb.position + speed * Time.deltaTime * direction);
            this.speed += acceleration * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }

        if (other.CompareTag("Player"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;


            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signY = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signY);
    }
    
    public void Stop()
    {
        this.stopped = true;
    }
    public void Go()
    {
        ChooseDirection();
        this.speed = this.initialSpeed;
        this.stopped = false;
    }
}
