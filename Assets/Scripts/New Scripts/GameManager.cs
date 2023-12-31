using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallManager ballManager;
    public bool HasGameStarted { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        HasGameStarted = false;
        UIManager.Instance.OnGameLoad();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!HasGameStarted)
            {
                HasGameStarted = true;
                UIManager.Instance.OnGameStart();
            } else if (!BallMovement.IsMoving)
            {
                UIManager.Instance.StartCountdown();
            }
            
        }
    }

    public void StartGame()
    {
        ballManager.BallGo();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
