using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public TextMeshProUGUI scoreText;
    private int scoreLeft = 0;
    private int scoreRight = 0;

    public bool started = false;

    private BallController ballController;

    private Vector3 startingPosition;

    public Starter starter;

    public TextMeshProUGUI instructionText;


    // Start is called before the first frame update
    void Start()
    {
        this.ballController = ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
        instructionText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started) return;

        
        if (Input.GetKey(KeyCode.Space))
        {
            instructionText.enabled = false;
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame()
    {
        this.ballController.Go();
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("Gol na esquerda");
        this.scoreRight++;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("Gol na direita");
        this.scoreLeft++;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.scoreText.text = $"{scoreLeft.ToString()} x {scoreRight}";
    }

    public void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }

}
