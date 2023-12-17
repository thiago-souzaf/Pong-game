using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFx : MonoBehaviour
{
    [SerializeField] GameObject goalExplosion;
    [SerializeField] GameObject wallHit;
    [SerializeField] GameObject playerHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) CreateEffect(playerHit);
        else if (collision.gameObject.CompareTag("Wall")) CreateEffect(wallHit);
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
}
