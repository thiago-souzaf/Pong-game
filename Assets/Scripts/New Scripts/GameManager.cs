using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;
    public bool HasGameStarted { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        HasGameStarted = false;
        UIManager.Instance.ShowInstruction(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HasGameStarted = true;
            ballMovement.ThrowBall();
            UIManager.Instance.ShowInstruction(false);
        }
    }
}
