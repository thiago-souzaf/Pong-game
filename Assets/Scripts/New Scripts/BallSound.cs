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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) audioSrc.PlayOneShot(hitPlayer);
        else if(collision.gameObject.CompareTag("Wall")) audioSrc.PlayOneShot(hitWall);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) audioSrc.PlayOneShot(goal);
    }
}
