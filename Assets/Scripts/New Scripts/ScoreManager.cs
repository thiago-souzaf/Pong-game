using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int scoreLeft, scoreRight;
    void Start()
    {
        scoreLeft = 0;
        scoreRight = 0;
    }

    public void ScoreGoal(string side)
    {
        if (side == "Left") scoreRight++;
        else if (side == "Right") scoreLeft++;
        UIManager.Instance.UpdateScore(scoreLeft, scoreRight);
    }
}
