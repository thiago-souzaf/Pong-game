using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] AudioClip hitPlayer;
    [SerializeField] AudioClip hitWall;
    [SerializeField] AudioClip goal;

    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();  
    }

    public void CollisionWithPlayer()
    {
        audioSrc.PlayOneShot(hitPlayer);
    }

    public void CollisionWithWall()
    {
        audioSrc.PlayOneShot(hitWall);
    }

    public void CollisionWithGoal()
    {
        audioSrc.PlayOneShot(goal);
    }
}
