using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{

    private Animator animator;
    public UnityEvent OnCountFinish;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartCountdown()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("HideCountdown 0"))
        {
            animator.SetTrigger("StartCountdown");
        }
    }

    // Finish Countdown is called by animation, once it finishes the countdown
    public void FinishCountdown()
    {
        OnCountFinish.Invoke();
    }
}
