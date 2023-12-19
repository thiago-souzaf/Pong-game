using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVFX : MonoBehaviour
{
    [SerializeField] GameObject goalExplosion;
    [SerializeField] GameObject wallHit;
    [SerializeField] GameObject playerHit;

    [SerializeField] Color defaultColor;
    [SerializeField] Color leftPlayerColor;
    [SerializeField] Color rightPlayerColor;
    private TrailRenderer trail;


    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        ChangeTrailColor(defaultColor);
    }

    private void CreateEffect(GameObject effect)
    {
        GameObject instance = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(instance, 4f);
    }

    public void GoalEffect()
    {
        // GoalDetector script calls this method, otherwise it would always instatiate effect after the ball resets position
        GameObject instance = Instantiate(goalExplosion, transform.position, Quaternion.identity);
        Destroy(instance, 4f);
    }

    private void ChangeTrailColor(Color color)
    {
        trail.startColor = color;
        trail.endColor = color;
    }

    public void EnableTrail(bool enable)
    {
        trail.enabled = enable;
    }

    public void ResetTrail()
    {
        trail.enabled = true;
        ChangeTrailColor(defaultColor);
    }

    public void CollisionWithPlayer(GameObject playerGameObject)
    {
        CreateEffect(playerHit);
        ESide playerSide = playerGameObject.GetComponent<PlayerMovement>().playerSide;
        if (playerSide == ESide.Left)
        {
            ChangeTrailColor(leftPlayerColor);
        }
        else
        {
            ChangeTrailColor(rightPlayerColor);
        }
    }

    public void CollisionWithWall()
    {
        CreateEffect(wallHit);
    }

    public void CollisionWithGoal()
    {
        GoalEffect();
        EnableTrail(false);
    }
}
