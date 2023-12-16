using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
    }
    public void UpdateScore(int scoreLeft, int scoreRight)
    {
        scoreTxt.text = scoreLeft + " x " + scoreRight;
    }
}
