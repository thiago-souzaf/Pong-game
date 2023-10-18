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
        instructionText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started) return;

        
        if (Input.GetKey(KeyCode.Space))
        {
            instructionText.gameObject.SetActive(false);
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
        ballController.CreateSpark(2);
        ballController.PlaySfx(2);
        ResetBall();
        
    }

    public void ScoreGoalRight()
    {
        Debug.Log("Gol na direita");
        this.scoreLeft++;
        UpdateUI();
        ballController.CreateSpark(2);
        ballController.PlaySfx(2);
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
