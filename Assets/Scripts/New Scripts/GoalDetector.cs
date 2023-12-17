using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalDetector : MonoBehaviour
{
    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            other.GetComponent<BallFx>().GoalEffect();
            onTriggerEnter.Invoke();
        }
    }
}
