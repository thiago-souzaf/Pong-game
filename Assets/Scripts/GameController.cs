using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("Gol na esquerda");
        this.scoreRight++;
        UpdateUI();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("Gol na direita");
        this.scoreLeft++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        this.scoreText.text = $"{scoreLeft.ToString()} x {scoreRight.ToString()}";
    }
}
