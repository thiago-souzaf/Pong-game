using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private BallMovement movement;
    private BallVFX vfx;
    private BallSound sound;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<BallMovement>();
        vfx = GetComponent<BallVFX>();
        sound = GetComponent<BallSound>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vfx.CollisionWithPlayer(collision.gameObject);
            movement.CollisionWithPlayer(collision.gameObject);
            sound.CollisionWithPlayer();

        } else if (collision.gameObject.CompareTag("Wall"))
        {
            vfx.CollisionWithWall();
            sound.CollisionWithWall();
        }
        movement.AllCollisions();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")){
            sound.CollisionWithGoal();
            vfx.CollisionWithGoal();
            ResetBall();
        }
    }
    public void ResetBall()
    {
        movement.ResetBallPosition();
    }

    public void BallGo()
    {
        movement.ThrowBall();
        vfx.ResetTrail();
    }
}
