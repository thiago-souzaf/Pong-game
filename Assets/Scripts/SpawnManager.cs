using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject powerUpPrefab;

    public float spawnInterval;
    public GameObject ball;
    private BallController ballController;

    public Transform playerLeftTransform;
    public Transform playerRightTransform;

    void Start()
    {
        ballController = ball.GetComponent<BallController>();
        StartCoroutine(SpawnPowerUp());
    }

    private IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            if (ballController.stopped)
            {
                yield return new WaitForSeconds(spawnInterval);
            } else
            {
                Vector3 spawnPosition = GetRandomSpawnPoint();
                Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Transform randomPlayer;
        float xAxis;
        int index = Random.Range(0, 2);

        if (index == 0)
        {
            randomPlayer = playerLeftTransform;
            xAxis = -7f;
        }
        else
        {
            randomPlayer = playerRightTransform;
            xAxis = 7f;
        }

        Vector3 spawnPoint = new(xAxis, 1, Random.Range(-5f, 5f));
        while ( Vector3.Distance(spawnPoint,randomPlayer.position) < 2f)
        {
            spawnPoint = new(xAxis, 1, Random.Range(-5f, 5f));
        }
        return spawnPoint;
    }
}
