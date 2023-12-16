using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int scoreLeft, scoreRight;
    public string scoreString;

    void Start()
    {
        scoreLeft = 0;
        scoreRight = 0;
    }

    public void ScoreGoal(string side)
    {
        if (side == "Left") scoreRight++;
        else if (side == "Right") scoreLeft++;
        Debug.Log("Gol feito no lado " + side);

        scoreString = scoreLeft.ToString() + ':' + scoreRight;
    }
}
