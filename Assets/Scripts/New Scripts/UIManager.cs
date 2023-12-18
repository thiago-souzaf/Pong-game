using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private GameObject instructionsCard;
    [SerializeField] private Countdown starterCountdown;

    private void Awake()
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

    private void ShowInstruction(bool show)
    {
        instructionsCard.SetActive(show);
    }

    public void StartCountdown()
    {
        starterCountdown.StartCountdown();
    }

    public void OnGameStart()
    {
        ShowInstruction(false);
        StartCountdown();
    }

    public void OnGameLoad()
    {
        ShowInstruction(true);
    }
}
